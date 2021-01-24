    public partial class Form1 : Form
    {
        private LoginUser validate_login(string user, string pass)
        {
             ...
             LoginUser usr = new LoginUser();
             MySqlDataReader login = cmd.ExecuteReader();
             
             while(login.Read())
             {
                     connect.Close();
                     usr.UserID = login["UserID"];
                     usr.valid = true;
             }    
             return usr;         
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ...
            LoginUser usr = new LoginUser();
            usr = validate_login(user, pass);
            if (usr.valid)
            {
               Console.WriteLine(String.Format("{0}", usr.UserID));
            }
        }
    }
    public class LoginUser
    {
        public Bool valid = false;
        public String UserID = "";
        // You can have more column name up to matching with your table column.
    }
