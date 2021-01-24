    public IActionResult GetData(string person_email)
        {
         try
            {
            String a = test_email;
            Console.WriteLine(a);
            return string.IsNullOrEmpty(a) ? 
            (IActionResult)BadRequest("email null or empty") : Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
