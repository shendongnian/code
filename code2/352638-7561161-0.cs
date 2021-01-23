    string ret = "Error";
    foreach(var item in listView1.Items)
    {
        if(item.Checked) { ret = item.Text; break; }
    }
    return ret;
