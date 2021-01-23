    public class OldWayValidationBinder : DefaultModelBinder {
        private readonly ModelMetadataProvider _metadataProvider;
        public ValidationBinder(ModelMetadataProvider metadataProvider) {
            _metadataProvider = metadataProvider;
        }
        protected ModelMetadata CreateModelMetadata(ModelBindingContext bindingContext) {
            var metadataProvider = new ModelMetadataProviderAdapter(
                _metadataProvider, bindingContext.PropertyFilter);
            return new ModelMetadata(metadataProvider,
                bindingContext.ModelMetadata.ContainerType,
                () => bindingContext.ModelMetadata.Model,
                bindingContext.ModelMetadata.ModelType,
                bindingContext.ModelMetadata.PropertyName);
        }
        protected override void OnModelUpdated(ControllerContext controllerContext, ModelBindingContext bindingContext) {
            base.OnModelUpdated(controllerContext, new ModelBindingContext(bindingContext) {
                ModelMetadata = CreateModelMetadata(bindingContext)
            });
        }
        private sealed class ModelMetadataProviderAdapter : ModelMetadataProvider {
            private readonly ModelMetadataProvider _innerMetadataProvider;
            private readonly Predicate<string> _propertyFilter;
            internal ModelMetadataProviderAdapter(
                ModelMetadataProvider innerMetadataProvider,
                Predicate<string> propertyFilter) {
                _innerMetadataProvider = innerMetadataProvider;
                _propertyFilter = propertyFilter;
            }
            public override IEnumerable<ModelMetadata> GetMetadataForProperties(object container, Type containerType) {
                return _innerMetadataProvider.GetMetadataForProperties(container, containerType)
                    .Where(metadata => _propertyFilter(metadata.PropertyName));
            }
            public override ModelMetadata GetMetadataForProperty(Func<object> modelAccessor, Type containerType, string propertyName) {
                return _innerMetadataProvider.GetMetadataForProperty(modelAccessor, containerType, propertyName);
            }
            public override ModelMetadata GetMetadataForType(Func<object> modelAccessor, Type modelType) {
                return _innerMetadataProvider.GetMetadataForType(modelAccessor, modelType);
            }
        }
    }
    internal sealed class ValidationProvider : ModelValidatorProvider {
        private readonly IValidationFactory _validationFactory;
        public ValidationProvider(IValidationFactory validationFactory) {
            _validationFactory = validationFactory;
        }
        public override IEnumerable<ModelValidator> GetValidators(ModelMetadata metadata, ControllerContext context) {
            if (metadata.ModelType != null) {
                IValidationService validationService;
                if (_validationFactory.TryCreateServiceFor(metadata.ModelType, out validationService)) {
                    yield return new ModelValidatorAdapter(metadata, context, validationService);
                }
            }
        }
        private sealed class ModelValidatorAdapter : ModelValidator {
            private readonly IValidationService _validationService;
            internal ValidationAdapter(ModelMetadata metadata,
                ControllerContext controllerContext,
                IValidationService validationService)
                : base(metadata, controllerContext) {
                _validationService = validationService;
            }
            public override IEnumerable<ModelValidationResult> Validate(object container) {
                if (Metadata.Model != null) {
                    IEnumerable<ValidationFault> validationFaults;
                    var validatableProperties = Metadata.Properties.Select(metadata => Metadata.ModelType.GetProperty(metadata.PropertyName));
                    if (!_validationService.TryValidate(Metadata.Model, validatableProperties, out validationFaults)) {
                        return validationFaults.Select(fault => new ModelValidationResult {
                            MemberName = fault.PropertyInfo.Name,
                            Message = fault.FaultedRule.Message
                        });
                    }
                }
                return Enumerable.Empty<ModelValidationResult>();
            }
        }
    }
