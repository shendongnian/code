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
More details in Microsoft Site : https://docs.microsoft.com/en-us/aspnet/web-api/overview/testing-and-debugging/unit-testing-controllers-in-web-api
