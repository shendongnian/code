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
It's been a while since I looked at it, but I believe the issue is in the extension `ShouldHaveValidationErrorFor` matching on property name and the property expression overload doesn't resolve the property name to 'Data[0].Id'. If you inspect the validation results you'll get a `ValidationError` object that looks something like this
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
EDIT:
Had a quick peek into the property expression overload, as per below
public IEnumerable<ValidationFailure> ShouldHaveValidationErrorFor<TProperty>(Expression<Func<T, TProperty>> memberAccessor)
{
  return ValidationTestExtension.ShouldHaveValidationError(this.Errors, ValidatorOptions.PropertyNameResolver(typeof (T), memberAccessor.GetMember<T, TProperty>(), (LambdaExpression) memberAccessor), true);
}
Presumably you could use another/write your own property name resolver to handle the case as it is settable. You'd probably have to dig into the expression to do it.
