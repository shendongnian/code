    public class MyModelMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        protected override ModelMetadata CreateMetadata(IEnumerable<System.Attribute> attributes, System.Type containerType, System.Func<object> modelAccessor, System.Type modelType, string propertyName)
        {
            var metadata = base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);
            var wizardStepAttr = attributes.OfType<WizardStepAttribute >().FirstOrDefault();
            if (wizardStepAttr != null)
            {
                metadata.AdditionalValues.Add("WizardStep", wizardStepAttr);
            }
            return metadata;
        }
    }
