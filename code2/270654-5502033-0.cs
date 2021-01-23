    IEnumerable myData = DynamicDataBuilder.GetDataList(dataSetData);
    ObservableCollection<Pages> myPages = new ObservableCollection<Pages>();
    foreach (var item in myData)
    {
        MyExpectedDataType data = item as MyExpectedDataType;
        If(data != null)
        { 
            Pages myPage = new Pages
            {
                ID = data.Id
            };
            MyPages.Add(myPage);
        }
    }
