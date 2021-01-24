    public class UserPetQueryResult
    {
        public int Id { get; set; }
        public string Email { get; set; }
    	public string PetName { get; set; }
    	public int PetAge { get; set; }
    }
    public static User GetUserByEmail(string email)
    {
        using var con = new SQLiteConnection(Globals.DbConnectionString);
    
         UserPetQueryResult  dbResult = con.QueryFirstOrDefault<UserPetQueryResult>($"SELECT id as Id,email as Email,pet_name as PetName,pet_age as PetAge FROM users WHERE email = @email COLLATE NOCASE", new
            {
                email
            });
    
        return new User() {
        		Email = dbResult.Email,
        		Pet = new Pet(){
        			Name = dbResult.PetName,
        			Age = dbResult.PetAge
        		}
        	};
    }
