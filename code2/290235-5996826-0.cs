    tbName.Text = query.Name;
    tbNum.Text = query.Num;
    tbAcctNum.Text = query.AcctNum;
    if(query.CorpAcct)
        rbtn.SelectedValue = "Yes"; \\Where "Yes" is one of the radio button values
    else
        rbtn.SelectedValue = "No";
    \\Could also use SelectedIndex, rbtn.SelectedIndex = 0 or 1
