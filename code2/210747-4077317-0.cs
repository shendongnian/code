    MatchCollection mColl = Regex.Matches(txtContent.Text.Trim() ,"(?<=:).+");
    for (int i = 0; i < mColl.Count; i++)
    {
       listBox1.Items.Add(mColl[i].Value.ToString().Trim());
    }
