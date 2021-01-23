    string[] str = richTextBox1.Text.Split(' ');
    string a="";
    string b="";
    for (int i = 0; i < str.Length; i++)
    {
        if (str.GetValue(i).ToString().Length > 2)
        {
            b = str.GetValue(i).ToString().Replace(str.GetValue(i).ToString().Substring(0, 1),   str.GetValue(i).ToString().Substring(0, 1).ToUpper());
        }
        else
        {
            b = str.GetValue(i).ToString();
        }
        a = a + " " + b;              
    }
    richTextBox1.Text = a;
