    var list = new[]
                     {
                         new {Name = "Dogs", Count = 5},
                         new {Name = "Cats", Count = 2}
                     };
     
     var json = list.ToGoogleDataTable()
                    .NewColumn(new Column(ColumnType.String, "Name"), x => x.Name)
                    .NewColumn(new Column(ColumnType.Number, "Count"), x => x.Count)
                    .Build()
                    .GetJson();
