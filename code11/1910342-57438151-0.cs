c#
public string[] user = { "username" };
public string[] password = { "password" };
//...
user.Append(textBox1.Text);
password.Append(textBox2.Text);
But you could reallocate the `user` and `password` arrays with something like this:
c#
public string[] user = { "username" };
public string[] password = { "password" };
//...
user = new[] { user[0], textBox1.Text };
password = new[] { password[0], textBox2.Text };
This is rather clumsy, though. You would probably be better off defining `user` and `password` as `List<String>`, i.e.:
c#
public List<string> user = new List<string>() { "username" };
public List<string> password = new List<string>() { "password" };
//...
user.Add(textBox1.Text);
password.Add(textBox2.Text);
