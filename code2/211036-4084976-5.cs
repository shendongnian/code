    var rows = new List<List<string>>()
    {
        new List<string>(){ "A1","B1","C1" },
        new List<string>(){ "A2","B2","C2" },
        new List<string>(){ "A3","B3","C3" },
    };
    listView1.Items.AddRange(
        rows.Select(
            (row, index) => new ListViewItem(
                new[] { index.ToString() }
                    .Concat(row)
                    .ToArray()
                )
            )
            .ToArray()
        );
