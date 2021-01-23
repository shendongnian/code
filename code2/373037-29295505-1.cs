    StringWriter csv = new StringWriter();
    // Generate header of the CSV file
    csv.WriteLine(string.Format("{0},{1},{2},{3}", "Header 1", "Header 2", "Header 3", "Header 4"));
    // Generate content of the CSV file
    foreach (var item in YourListData)
    {
        csv.WriteLine(string.Format("{0},{1},{2},{3}", item.Data1, "\"" + item.Data2+ "\"", item.Data3, "\"" + item.Data4 + "\""));
    }
    return File(new System.Text.UTF8Encoding().GetBytes(csv.ToString()), "application/csv", string.Format("{0}{1}", "YourFileName", ".csv"));
