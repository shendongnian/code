    public ObservableCollection<DebtEntries> mySource { get; set; }
    . . .
    mySource = new ObservableCollection<DebtEntries>();
    mySource.Add(new DebtEntries { Name = "xxx", Usage="xxx",Value="xxx",CreationDate="xxx"});
    //. . .
    DebtsList.ItemsSource = mySource;
