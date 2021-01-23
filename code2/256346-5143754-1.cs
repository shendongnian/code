    StringBuilder sb = new StringBuilder();
    for(int i = 1; i < 30; i++){
        TextBox tb = FindControl("TextBox" + i);
        Checkbox cb = FindControl("CheckBox" + i);
        sb.AppendFormat("TextBox{0}={1}; {2}", i, tb.Text, cb.Checked);
    }
    string result = sb.ToString();
    // Now write 'result' to your text file.
