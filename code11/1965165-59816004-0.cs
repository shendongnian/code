public string CalculateMD5Hash(string input)
{
     MD5 md5 = System.Security.Cryptography.MD5.Create();
     byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
     byte[] hash = md5.ComputeHash(inputBytes);
     StringBuilder sb = new StringBuilder();
     for (int i = 0; i < hash.Length; i++)
     {
          sb.Append(hash[i].ToString("x2"));
     }
     return sb.ToString();
}
**Next, you need to grab the salt from your SQL database**
string salt;
MySqlConnection con2 = new MySqlConnection("Server=hostname;Database=databasename;user=username;Pwd=password;SslMode=none");
MySqlCommand cmd = new MySqlCommand("SELECT * FROM mybb_users", con2);
con2.Open();
MySqlDataReader reader = cmd.ExecuteReader();
while (reader.Read())
{
     salt = reader.GetString("salt");
}
**Then, you need to hash the password the user inputs**
string passwordHash = CalculateMD5Hash(CalculateMD5Hash(salt) + CalculateMD5Hash(password));
**Lastly, you can login**
MySqlConnection con = new MySqlConnection("Server=remotemysql.com;Database=fofBv30s0W;user=fofBv30s0W;Pwd=sUFDdE8Tun;SslMode=none");
cmd = new MySqlCommand();
con.Open();
cmd.Connection = con;
cmd.CommandText = "SELECT * FROM mybb_users where username='" + username + "' AND password='" + passwordHash + "'";
dr = cmd.ExecuteReader();
if (dr.Read())
{
     // Do what you want after login
}
else
{
     MessageBox.Show("Invalid Login please check username and password");
}
con.Close();
**Together the code should look something like this**
public string CalculateMD5Hash(string input)
{
     MD5 md5 = System.Security.Cryptography.MD5.Create();
     byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
     byte[] hash = md5.ComputeHash(inputBytes);
     StringBuilder sb = new StringBuilder();
     for (int i = 0; i < hash.Length; i++)
     {
          sb.Append(hash[i].ToString("x2"));
     }
     return sb.ToString();
}
private void button_Click(object sender, EventArgs e)
{
     string salt;
     MySqlConnection con2 = new MySqlConnection("Server=hostname;Database=databasename;user=username;Pwd=password;SslMode=none");
     MySqlCommand cmd = new MySqlCommand("SELECT * FROM mybb_users", con2);
     con2.Open();
     MySqlDataReader reader = cmd.ExecuteReader();
     while (reader.Read())
     {
          salt = reader.GetString("salt");
     }
     string passwordHash = CalculateMD5Hash(CalculateMD5Hash(salt) + CalculateMD5Hash(password));
     MySqlConnection con = new MySqlConnection("Server=remotemysql.com;Database=fofBv30s0W;user=fofBv30s0W;Pwd=sUFDdE8Tun;SslMode=none");
     cmd = new MySqlCommand();
     con.Open();
     cmd.Connection = con;
     cmd.CommandText = "SELECT * FROM mybb_users where username='" + username + "' AND password='" + passwordHash + "'";
     dr = cmd.ExecuteReader();
     if (dr.Read())
     {
          // Do what you want after login
     }
     else
     {
          MessageBox.Show("Invalid Login please check username and password");
     }
     con.Close();
}
