            [HttpGet]
            public async Task <IActionResult> GetAllUsers (string type)
            {
               
                        List <User> rawUsers = UserExternalService.GetAllUser()
    
                        if (type == "first-name")
                        {
                            return Ok (rawUsers.OrderBy (o => o.FirstName) .ToList ());
                        }
                        else if (type == "score")
                        {
                            return Ok (rawUsers.OrderBy (o => o.Score) .ToList ());
                        }
    
                        return Ok (rawUsers);
                
            }
    
    This method would take 3 unit test
    
    Example:
    
            public class The_Method_GetAllUsers
            {
                  
                [Fact]
                public async void Should_return_user_when_type_is_name
                {
                   Assert.IsType<OkObjectResult>>(this.Sut.GetAllUser("name"));
                }
    
                [Fact]
                public async void Should_return_user_when_type_is_score
                {
                   Assert.IsType <OkObjectResult>>(this.Sut.GetAllUser("score"));
                }
                [Fact]
                public async void Should_return_user_when_type_its_not_name_and_score
                {
                   Assert.IsType <OkObjectResult>>(this.Sut.GetAllUser("surname"));
                }
            }
