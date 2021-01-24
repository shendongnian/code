 c#
public Async Task<IActionResult> Create(IFormCollection collection)
{
        try
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Organisation", collection["OrganisationID"]);
            parameters.Add("@ClientID1", collection["ClientID"]);
            parameters.Add("@Team", collection["TeamID"]);
            parameters.Add("@Email", collection["Email"]);
            parameters.Add("@UserName", collection["UserName"]);
            parameters.Add("@Password", collection["Password"]);
            parameters.Add("@FirstName", collection["FirstName"]);
            parameters.Add("@LastName", collection["LastName"]);
            var affectedRows = _dapperRepo.CreateUser(parameters);
            using (IDbConnection conn = Connection)
            {            
                string sproc = "EXEC sproc_NewUser @Organisation, @Client1, @Team, @Email  @UserName, @Password, @FirstName, @LastName";
                conn.Open();
                var result = await conn.QueryAsync(sproc, parameters, commandType: CommandType.StoredProcedure);
                var result2 = result.FirstOrDefault();
            }   
            return RedirectToAction(nameof(Index));
        }
        catch (Exception)
        {
            throw;
        }
    }
