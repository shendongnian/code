    // Here, I construct a simple table for demonstration
    var table = new DataTable();
    var column = table.Columns.Add("Tags", typeof(string));
    table.Rows.Add("Tag1");
    table.Rows.Add("Tag1, Tag2");
    table.Rows.Add("Tag2, Tag3");
    table.Rows.Add("Tag1, Tag2, Tag3");
    table.Rows.Add("Tag4, Tag6");
    // The separator is convenient for using the string.Split override
    // that strips empty results
    var separator = new[] { ",", " " };
    // For the demo, we'll sort by number of tags matching the third row
    var current = table.Rows[2];
    // This splits the string into an array for convenient processing later
    var currenttags = current.Field<string>("Tags")
                             .Split(separator, StringSplitOptions.RemoveEmptyEntries);
    // The query splits out each tags field into an array convenient for processing,
    // counts the number of tags contained in the currenttags array,
    // sorts, and then selects the entire row.
    var query = from row in table.AsEnumerable()
                let tags = row.Field<string>("Tags")
                              .Split(separator, StringSplitOptions.RemoveEmptyEntries)
                let count = tags.Count(t => currenttags.Contains(t))
                orderby count descending
                select row;
