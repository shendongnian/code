    Dictionary<string,From2> myForm2s = new Dictionary<string,Form2>();
        
    public void Send(string body, string name)
    {
       Form2 frm = null;
       if(!myForm2s.tryGetValue(name,out frm))
       {
          frm = new Form2(body);
          myForm2s[name] = frm;
          frm.Text = name;
          frm.Show();
       }
       else
       {
          frm.listBox1.Items.Add(body); // assuming listBox1 is public
          frm.Show();
          frm.BringToFront();
       }
    }
 
