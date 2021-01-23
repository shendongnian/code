    List<string> ListLabelNames = new List<string>() { /* Your label name list*/ };
    foreach (Label TmpLabel in this.Controls)
    {
        foreach (string strTmp in ListLabelNames)
        {
            if (String.Compare(TmpLabel.Name, strTmp, true) == 0)
                TmpLabel.ForeColor = System.Drawing.Color.Black;
        }
    }
