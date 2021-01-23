    var a = // get all items (returns a collection of Test2)
    List<MyViewModel> collection = new List<MyViewModel>();
    foreach (Test2 t in a)
    {
        MyViewModel vm = Mapper.Map<Test2, MyViewModel>(t);
        vm.SetDateFormat(t.DateTimeDate, DateFilters.All.ToString());
        collection.Add(vm);
    }
