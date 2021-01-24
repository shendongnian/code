public class Authentication
{
    public void Login()
    {
            try
            {
                string query = "Select * from [UserTbl] where username='" + txtusername.Text + "' and password='" + txtpassword.Text + "'";
                DBConnect db = new DBConnect();
                DataTable dt = db.GetData(query);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Login successful");
                }
                else
                {
                    MessageBox.Show("Username and Password Incorrect");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
    }
}
public void button1_Click(object sender, EventArgs e)
{
    var authentication = new Authentication();
    authentication.Login();
}
(I'm sidestepping the fact that this doesn't seem to do anything other than display a result. Presumably you're doing something else not seen in this code.)
This might be sufficient if the method is absolutely only intended to be used in the context of this single application. But what if you want this to be usable in some context where `MessageBox.Show` isn't available?
You can separate that by having your method return a result. That way the method indicates whether something was successful, and your UI code determines if or how to communicate that to a user. In that case your method could look more like this:
    public bool Login()
    {
        string query = "Select * from [UserTbl] where username='" + txtusername.Text + "' and password='" + txtpassword.Text + "'";
        DBConnect db = new DBConnect();
        DataTable dt = db.GetData(query);
        if (dt.Rows.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
        // or, just
        // return dt.Rows.Count > 0;
    }
In many cases it would make sense to return some sort of `Result` class with more detail, but for this example, a `bool` representing success of failure is enough.
Now your UI code can do this:
public void button1_Click(object sender, EventArgs e)
{
    try
    {
        var authentication = new Authentication();
        var success = authentication.Login();
        if (success)
        {
            MessageBox.Show("Login successful");
        }
        else
        {
            MessageBox.Show("Username and Password Incorrect");
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
}
If you needed to reuse the above code and didn't want to duplicate it you could create a separate control, moving both the button and the click handler into it.
