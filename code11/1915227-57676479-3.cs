using System.ComponentModel.DataAnnotations;
/*other using*/
[Fact]
public void UserValidationError()
{
	//Arrange
	BaseUserDTO userDTO = new BaseUserDTO
    {
       FirstName = "222A@@@",
       LastName = "Test",
       Email = "Test@test.com",
       PhoneNumber = "(111)111-1111",
       Role = 0,
       Password = "1234567A",
       RetypePassword = "1234567A"
    };
	//ACT
    var lstErrors = ValidateModel(userDTO);
	//ASSERT
	Assert.IsTrue(lstErrors.Count == 1);   
	//Or 
	Assert.IsTrue(lstErrors.Where(x => x.ErrorMessage.Contains("Use only Latin characters")).Count() > 0);
}
//http://stackoverflow.com/questions/2167811/unit-testing-asp-net-dataannotations-validation
        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }
More details in Microsoft Site : https://docs.microsoft.com/en-us/aspnet/web-api/overview/testing-and-debugging/unit-testing-controllers-in-web-api
