    var tableList = new Dictionary<string, Dictionary<string, string>>
    {
        { "Table1", new Dictionary<string, string>
                    {
                        { "Field1", "abc" },
                        { "Field2", "def" },
                        { "Field3", "ghi" },
                        { "Field4", "jkl" },
                    }
        },
        { "Table2", new Dictionary<string, string>
                    {
                        { "Field1", "xyz" },
                        { "Field2", "uvw" },
                        { "Field3", "rst" },
                    }
        },
        { "Table3", new Dictionary<string, string>
                    {
                        { "Field1", "123" },
                        { "Field2", "456" },
                    }
        },
    };
    // Display tables and corresponding fields
    txtMessage.Text = String.Join("\r\n",
        tableList.SelectMany(table =>
            table.Value.Select(fieldList =>
                String.Format("Table={0}, Field={1} - {2}",
                    table.Key, fieldList.Key, fieldList.Value)
            )
        ).ToArray()
    );
    // (I hope you have this in a separate method)
    // Try to find tables and fields in the lists, and list the value if found
    string tableToFind = "Table2";
    string fieldToFind = "Field2";
    var builder = new StringBuilder(txtMessage.Text); // mostly useful if you have a 
                                                      // lot of different strings to add
    Dictionary<string, string> foundTable;
    if (tableList.TryGetValue(tableToFind, out foundTable))
    {
        builder.AppendLine()
            .Append("Table=" + tableToFind + " exist in table list");
        string foundField;
        if (foundTable.TryGetValue(fieldToFind, out foundField))
        {
            builder.AppendLine()
                .AppendFormat("Table={0}, Field={1} with value={2} exist in table list",
                    tableToFind, fieldToFind, foundField);
        }
    }
    txtMessage.Text = builder.ToString();
