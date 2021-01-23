    // Get the current values
    var currentRowValues = m_ASPxGridView.GetCurrentPageRowValues("ID", "SID")
        // Cast each object to an array of objects
        .Cast<object[]>()
        // Project the two members of the array into an anonymous type
        .Select(x => new { ID = x[0].ToString(), SID = x[1].ToString() });
    var selectedRowValues = m_ASPxGridView.GetSelectedFieldValues("ID", "SID")
        // Cast each object to an array of objects
        .Cast<object[]>()
        // Project the two members of the array into an anonymous type
        .Select(x => new { ID = x[0].ToString(), SID = x[1].ToString() });
    // Compare the two collections to get the unselected row values
    var unselected = currentRowValues.Except(selectedRowValues);
