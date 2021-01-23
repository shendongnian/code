    // Get the current and selected values as anonymous types
    var currentRowValues = m_ASPxGridView.GetCurrentPageRowValues("ID", "SID")
        .Select(x => new { ID = x[0].ToString(), SID = x[1].ToString() });
    var selectedRowValues = m_ASPxGridView.GetSelectedFieldValues("ID", "SID")
        .Select(x => new { ID = x[0].ToString(), SID = x[1].ToString() });
    // Compare the two collections to get the unselected row values
    var unselected = currentRowValues.Except(selectedRowValues);
