    foreach (ListViewItem itm in listView1.Items)
    {
    writefile.Write(uniEncoding.GetBytes(f.Text), 0,uniEncoding.GetByteCount(itm.Text));
    //OR
    //sw.WriteLine(itm.Text);
    }
    writefile.Close();
    //OR
    //sw.Close();
}
