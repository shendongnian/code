    public class MyModelMetadataProvider : DataAnnotationsModelMetadataProvider 
    {
        protected override ModelMetadata CreateMetadata(
            IEnumerable<Attribute> attributes,
            Type containerType,
            Func<object> modelAccessor,
            Type modelType,
            string propertyName)
        {
            var modelMetadata = base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);
            var additionalValues = attributes.OfType<WizardStepAttribute>().FirstOrDefault();
            if (additionalValues != null)
            {
                modelMetadata.AdditionalValues.Add("Name", additionalValues.Name);
                modelMetadata.AdditionalValues.Add("StepNumber", additionalValues.StepNumber);
            }
            return modelMetadata;
        }
    }
