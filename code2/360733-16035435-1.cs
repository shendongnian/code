    string tmppath = @".....\temp.txt";
    FileStream writefile = new FileStream(tmppath, FileMode.Open, FileAccess.Write);
    //StreamWriter sw = new StreamWriter(writefile);//To write line
    if (File.Exists(tmppath))
    {
    foreach (ListViewItem itm in listView1.Items)
    {
    writefile.Write(uniEncoding.GetBytes(f.Text), 0,uniEncoding.GetByteCount(itm.Text));
    //OR
    //sw.WriteLine(itm.Text);
    }
    writefile.Close();
    //OR
    //sw.Close();
