    using (Graphics graphics = uiMarksDisplayTextBox.CreateGraphics())
    {
        int nMaxLength = (int)Collumns.Concat(Names).Max(c => graphics.MeasureString(c + " ", uiMarksDisplayTextBox.Font).Width);
        SendMessage(uiMarksDisplayTextBox.Handle, EM_SETTABSTOPS, 1, new int[] { nMaxLength });
    }
    uiMarksDisplayTextBox.Text = string.Join("\t", Collumns);
    uiMarksDisplayTextBox.Text += System.Environment.NewLine;
    for (int i = 0; i < Names.Length; i++)
    {
        uiMarksDisplayTextBox.Text += Names[i];
        for (int x = 0; x < 3; x++)
        {
            uiMarksDisplayTextBox.Text += "\t" + Grade[i, x];
        }
        uiMarksDisplayTextBox.Text += "\t" + FinalGrade[i];
        uiMarksDisplayTextBox.Text += System.Environment.NewLine;
    }
