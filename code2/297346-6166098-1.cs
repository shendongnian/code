    void SetVisibility1(params TextBox[] visibleTextBoxes)
    {
        var visibleList = visibleTextBoxes.ToList();
        foreach (TextBox t in allTextBoxes)
        {
            t.Visible = visibleList.Contains(t);
        }
    }
    
    void SetVisibility2(params TextBox[] visibleTextBoxes)
    {
        allTextBoxes.Except(visibleTextBoxes).ToList().ForEach(t => t.Visible = false);
        visibleTextBoxes.ToList().ForEach(t => t.Visible = true);
    }
    void SetVisibility3(params TextBox[] visibleTextBoxes)
    {
        var visibleList = visibleTextBoxes.ToList();
        allTextBoxes.ToList().ForEach(t => t.Visible = visibleList.Contains(t));
    }
