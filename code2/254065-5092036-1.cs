    List<string> values = new List<string>();
    foreach(Control c in this.Controls)
    {
        if(c is TextBox)
        {
            /*I didnt need to cast in my intellisense, but just in case!*/
            TextBox tb = (TextBox)c;
            values.Add(tb.Text);
        }
     }
     string[] array = values.ToArray();
