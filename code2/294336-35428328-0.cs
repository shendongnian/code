       var ds = new System.Data.DataSet();
                var dt = ds.Tables.Add();
                dt.Columns.Add("[a[b]c", typeof(decimal));
                dt.Rows.Add(1);
                dt.Rows.Add(2);
                dt.Rows.Add(3);
                dt.Select("[[a[b\\]c]=3").Length.ShouldBe(1);
