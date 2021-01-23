    foreach (var month in Enum.GetValues(typeof(Months)))
        cboMonthFrom.Items.Add(month);
    [...]
    // This works now
    Months selectedMonth = (Months)cboMonthFrom.SelectedItem;
