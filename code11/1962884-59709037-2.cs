    public void updateName()
    {
        // Do this conversion before the loop. We need to do it only once.
        int selectedCode = Convert.ToInt32(txtExtCode.Text);
        string[] lines = File.ReadAllLines(directoryFile);
        for (int i = 0; i < lines.Length; i++)
        {
            // Split current line into three fields
            string[] fields = lines[i].Split(',');
            int extCode = Convert.ToInt32(fields[2]);
            if (extCode == selectedCode)
            {
                fields[0] = txtSurname.Text;
                fields[1] = txtForename.Text;
                lines[i] = String.Join(",", fields);
                // If the extension code is unique, leave the for-loop
                break;
            }
        }
        File.WriteAllLines(directoryFile, lines);
    }
