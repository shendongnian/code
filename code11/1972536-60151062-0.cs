    public class CustomMetadataValidationProvider : DataAnnotationsModelValidatorProvider
    {
     protected override IEnumerable<ModelValidator> GetValidators(ModelMetadata metadata, ControllerContext context, IEnumerable<Attribute> attributes)
    {
        //go to db if you want
        //var repository = ((MyBaseController) context.Controller).RepositorySomething;
        //find user if you need it
        var user = context.HttpContext.User;
        if (!string.IsNullOrWhiteSpace(metadata.PropertyName) && metadata.PropertyName == "FirstName")
            attributes = new List<Attribute>() {new RequiredAttribute()};
        return base.GetValidators(metadata, context, attributes);
     }
    }
