public void Create(UserDTO u, bool isSeller )
{
...
            cmd.Parameters.Add("@NameOfBusiness", System.Data.SqlDbType.NVarChar).Value = 
                   isSeller ? u.NameOfBusiness : null;
# Option C. Craft 
`Create` could take in a `bool` parameter and modify the query and the `Parameters` accordingly. Something like the following. 
 
public void Create(UserDTO u, bool isSeller)
{
    using (SqlConnection con = new SqlConnection(connectionString))
    {
        string query = "INSERT INTO [dbo].[User](FirstName, LastName, UserName, Password, HouseNumber, Adress, Zip" +
            (isSeller ? "NameOfBusiness" : "") +
            ") VALUES(@FirstName, @LastName, @UserName, @Password, @HouseNumber, @Adress, @Zip" +
            (isSeller ? "@NameOfBusiness" : "") +
            ")";
        using (SqlCommand cmd = new SqlCommand(query, con))
        {
            // (...)
            cmd.Parameters.Add("@Zip", System.Data.SqlDbType.NVarChar).Value = u.Zip;
            if(isSeller) {
                cmd.Parameters.Add("@NameOfBusiness", System.Data.SqlDbType.NVarChar).Value = u.NameOfBusiness;
            }
