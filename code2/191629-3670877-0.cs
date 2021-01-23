    foreach (string el in files_in_folder)
    {
        bool isDicomFile = false;
        using (FileStream fs = new FileStream(el, FileMode.Open))
        {
            byte[] b = new byte[4];
            fs.Read(b, 128, b.Length);
            ASCIIEncoding enc = new ASCIIEncoding();
            string verification = enc.GetString(b);
            if (verification == "DICM")
                isDicomFile = true;
            fs.Close();
        }
        if (isDicomFile)
            listView1.Items.Add(new ListViewItem(el));
        // I would discourage the use of this else, since even
        // if only one file in the list fails, the TextBox.Text
        // will still be set to "This is not a DICOM file".
        else
            textBox1.Text = "This is not a DICOM file";
    }
