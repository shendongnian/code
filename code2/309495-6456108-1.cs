    // Create a class to hold the information you want to bind, 
    // you could use anonymous types if preferred
    class MyDataRow
    {
        public long ID { get; set; }
        public string AnotherColumn { get; set; }
        public string AndAnotherColumn { get; set; }
    }
    // then later on when creating that list use something along the lines of:
    List<MyDataRow> myList = dt.DefaultDataView.ToTable(True, "ID").AsEnumerable().Select(x => new MyDataRow { ID = x.ID }).ToList()
    // you now have a list of MyDataRow which you can work with
    // for example...
    if (myList.Any())
        myList.First().AnotherColumn = "foo";
    // as an exmaple of using an anoymous type (not my preference, but an option nonetheless)
    var anonymousList = dt.DefaultDataView.ToTable(True, "ID").AsEnumerable().Select(x => new { ID = x.ID, whateverYouWantToCallIt = "some other data here or leave blank and fill later" }).ToList()
    // you can work with the anonymous list in much the same way, it just isn't explicitly declared
    // and the properties are Read Only
    if (anonymousList.Any())
        Console.WriteLine(anonymousList.First().whateverYouWantToCallIt);
