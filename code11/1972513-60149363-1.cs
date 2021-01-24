    foreach (var line in File.ReadLines(FileName))
    {
        if (line.Contains ("Description1") )
        {
            MessageBox.Show ("Description1 found");
            if (line.Contains ("\"\"") )   // <--- Line substituted
            {                                                 
                MessageBox.Show ("ERROR! Empty Description1 found.");
            }
        }
    }
