    private void btnOpenFile_Click(object sender, EventArgs e)
    {
        DataBase db = new DataBase(@"C:\Users\JonDoe\Desktop\DataBase.txt");
        db.Read();
    
        using (OpenFileDialog ofd = new OpenFileDialog())
        {
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(ofd.FileName))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string partNumber = line.Split(new string[] { "," }, StringSplitOptions.None)[7];
                        if (partNumber[0] == '\"')
                            partNumber = partNumber.Substring(1, partNumber.Length - 2);
                        db.AddRecord(partNumber, Path.GetFileNameWithoutExtension(ofd.FileName));
                    }
                }
                db.Write();
            }
        }
    }
