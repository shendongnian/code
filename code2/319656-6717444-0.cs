    if (lbItems.SelectedIndex == -1)
    {
        if (rdBtnMedium.Checked && rdBtnN.Checked)
        {
            using (StreamWriter File = new StreamWriter(filepath))
            {
                foreach (string item in lbItems.Items)
                {
                    saveAllText = mediumNo + " " + item;
                    outputFile.WriteLine(saveText);
                }
            }
        }
        else if (rdBtnMed.Checked)
        {
            using (StreamWriter File = new StreamWriter(filepath))
            {
                foreach (string item in lbItems.Items)
                {
                     saveAllText = medium + " " + item;
                     outputFile.WriteLine(saveText);
                }
            }
        }                        
    }
