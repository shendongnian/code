[TestCase(null)]
[TestCase("")]
public void Id_InvalidValue_HasError(string id)
{
    var fixture = new Fixture();
    var datum = fixture.Build<PatchDTO.Datum>().With(x => x.Id, id).Create();
    var dto = fixture.Build<PatchDTO>().With(x => x.Data, new List<PatchDTO.Datum> { datum }).Create();
    var validator = new PatchDTOValidator();
    
    var validationResult = validator.TestValidate(dto);
    validationResult.ShouldHaveValidationErrorFor("Data[0].Id")
        .WithErrorMessage("Invalid 'Data.Id' value");
}
It's been a while since I looked at it, but I believe the issue is in the extension `ShouldHaveValidationErrorFor` matching on property name and the typed overload doesn't resolve the property name to 'Data[0].Id'. If you inspect the validation results you'll get a `ValidationError` object that looks something like this
{
   "PropertyName":"Data[0].Id",
   "ErrorMessage":"Invalid 'Data.Id' value",
   "AttemptedValue":"",
   "CustomState":null,
   "Severity":0,
   "ErrorCode":"NotEmptyValidator",
   "FormattedMessageArguments":[
   ],
   "FormattedMessagePlaceholderValues":{
      "PropertyName":"Id",
      "PropertyValue":""
   },
   "ResourceName":null
}
