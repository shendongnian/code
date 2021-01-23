    public static bool ValidateUser(string userName, string password)
    {
    	using (var connection = new SqlConnection("connectionString"))
    	using (var command = connection.CreateCommand())
    	{
    		command.CommandText = "SELECT dbo.checkUserExists (@userName, @password)";
    		command.Parameters.Add("@userName", SqlDbType.NVarChar, 25).Value = userName;
    		command.Parameters.Add("@password", SqlDbType.NVarChar).Value = GenerateHash(password);
    
    		connection.Open();
    		return (bool)command.ExecuteScalar();
    	}
    }
    private static string GenerateHash(string value)
    {
    	return Convert.ToBase64String(new System.Security.Cryptography.HMACSHA1(Encoding.UTF8.GetBytes("salt")).ComputeHash(Encoding.UTF8.GetBytes(value)));
    }
    IF OBJECT_ID(N'checkUserExists', N'FN') IS NOT NULL
    DROP FUNCTION checkUserExists
    GO
    CREATE FUNCTION checkUserExists
    (
    	@userName NVARCHAR(25),
    	@password NVARCHAR(255)
    )
    RETURNS BIT
    AS
    BEGIN
    	RETURN ISNULL((
    		SELECT 1
    		FROM users
    		WHERE
    			name = @userName
    		AND password = @password
    	), 0)
    END
