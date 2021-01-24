    foreach(Control c in pnlTaskAssignation.Controls)  //References the member variable defined above
    {
        if (c is ComboBox)
        {
            countLabels++;
        }
    }
