    List<string> names = new List<string>() // list of names to check for
    {                                       // if a name is not in this list
       "Andrea","Brittany","Eric"           // the error message will show
    };                                      // otherwise, the calculation will be performed
    
    if ( names.Contains(TextBox1.Text) )
    {
        Commission.Text = (Convert.ToDouble(textBox2.Text) / 10).ToString();
    }
    else
    {
        MessageBox.Show("The spelling of the name is incorrect", "Bad Spelling");
    }
