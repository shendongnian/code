    for (int i = 0; i < a.Length; i++)
    {
       CheckBox user = new CheckBox();
       d = (user_detail)a.GetValue(i);
       user.Name = d.First_name;
       user.Content= d.First_name;
       listBox1.Items.Add(user);                
    }
