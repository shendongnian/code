    [Given(@"there is some invalid input:")]
    public void GivenThereIsSomeInvalidInput(Table table)
    {
       foreach (var row in table.Rows)
       {
           string info1= = row["<Here goes column Name>"];
           string info2= = row["<Column Name2..>"];
       }
    }
