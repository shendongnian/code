CS
if (result.HasRows)
{
    MessageBox.Show("Login Success");
}
else
{
    MessageBox.Show("Login Failed");
}
or
CS
if (reader.Read())
{
    string finalUsername = result[3].ToString();
    string finalPass = result[4].ToString();
    
    MessageBox.Show("Login Success");
}
else
{
    MessageBox.Show("Login Failed");
}
I would not recommend querying with `SELECT *` and then referencing fields by their index.  It would be better to write `SELECT emailAddr, password FROM Teachers ...` and access the fields by their name, such as `result["emailAddr"]`.
Also, you have a **SQL injection vulnerability**. You should look up what this means and how to parameterize a query.
Also, it appears you are **storing passwords in plain text**.  You should look up password hashing and proper storage.
