    Private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        if(!char.IsDigit(e.KeyChar)&&!char.IsControl(e.KeyChar)) //only digit but still allow the user to use control key to Copy&Paste etc. But you need to apply validating with paste text as well
        {
           e.Handled=true;
        }
    }
