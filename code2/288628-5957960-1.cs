    StringBuilder sb = new StringBuilder();
    // Appending string to your StringBuilder string value.
    sb.AppendLine("BLAH BLAH");
    if (saveFile.ShowDialog() == DialogResult.OK)
    {
        // Keep the previous file text .. By inserting it in the begining of the 
        // StringBuilder string value. 
        sb.Insert(0, File.ReadAllText(saveFile.FileName) + Environment.NewLine);
        // Insert File Name in the begining of the StringBuilder string value.
        sb.Insert(0, saveFile.FileName + Environment.NewLine);
        File.WriteAllText(saveFile.FileName, sb.ToString());
    }
