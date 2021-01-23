public IEnumerable&lt;ModelClientValidationRule&gt; GetClientValidationRules(ModelMetadata metadata, ControllerContext context)    
{
    var modelClientValidationRule = new ModelClientValidationRule
    {
        ValidationType = <b>"requiredif"</b>,
        ErrorMessage = ErrorMessageString
    };
    modelClientValidationRule.ValidationParameters.Add(<b>"target"</b>, prop.PropName);
    modelClientValidationRule.ValidationParameters.Add(<b>"values"</b>, prop.CompValues);
    return new List&lt;ModelClientValidationRule&gt; { modelClientValidationRule };
}
