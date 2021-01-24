     class MyViewModel
    {
        public ObservableCollection<MyModel> MyModels { get; set; }
        public MyViewModel()
        {
            MyModels = new ObservableCollection<MyModel>();
            MyModels.Add(new MyModel() { State = "State Name", Votes = "Electoral Votes" 
            });
            MyModels.Add(new MyModel() { State = "Oregon ", Votes = "7" });
            MyModels.Add(new MyModel() { State = "Washington", Votes = "8" });
            MyModels.Add(new MyModel() { State = "California", Votes = "55" });
            MyModels.Add(new MyModel() { State = "lost1", Votes = "22" });
            MyModels.Add(new MyModel() { State = "lost2", Votes = "24" });
            MyModels.Add(new MyModel() { State = "lost3", Votes = "25" });
            MyModels.Add(new MyModel() { State = "lost4", Votes = "26" });
            MyModels.Add(new MyModel() { State = "lost5", Votes = "27" });
            int sumVotes = 0;
            for (int i=1;i<MyModels.Count;i++)
            {
                sumVotes+= Int32.Parse(MyModels[i].Votes);
            }
            MyModels.Add(new MyModel() { State = " ", Votes = 
            "sum"+sumVotes.ToString()});
        }
    }
