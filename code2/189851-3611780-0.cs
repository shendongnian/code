    //test data
    DataTable table = new DataTable();
            var column = table.Columns.Add("Tags", typeof(string));
            table.Rows.Add("Tag1");
            table.Rows.Add("Tag1,Tag2");
            table.Rows.Add("Tag2,Tag3");
            table.Rows.Add("Tag1,Tag2,Tag3");
            table.Rows.Add("Tag4,Tag6");
            string[] currentTags = new string[] { "Tag1", "Tag2", "Tag3" };
    
    //actual code
            var a = from row in table.AsEnumerable()
                    let cData = (row["Tags"] as string).Split(new char[] { ',' }).Intersect(currentTags)
                    orderby cData.Count() descending
                    select cData;
