 
            [HttpPost("{Register}")]
            public async Task<ActionResult<object>> Register([FromBody]User userModel)
            { 
                try
                {
                    UserForRegisterDTO.Username = userModel.Username;
    
                    UserForRegisterDTO.Username = userModel.Password;
    
                    return UserForRegisterDTO.Username;
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.Message);
                }
                return null;
                
            }
    
