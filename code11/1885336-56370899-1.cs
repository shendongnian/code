    private Random r = new Random();
        public List<ViewModel> GenerateCollection()
        {
            List<ViewModel> collection = new List<ViewModel>();
            for (int i = 0; i < 500; i++)
            {
                ViewModel vm = new ViewModel();
                vm.GetData = GenerateData();
                vm.LegendTitle = "ViewModel " + i;
                collection.Add(vm);
            }
            return collection;
        }
        public List<Data> GenerateData()
        {
            List<Data> data = new List<Data>();
            data.Add(new Data { Category = "Apple", Value = r.Next(1, 20) });
            data.Add(new Data { Category = "Orange", Value = r.Next(10, 30) });
            data.Add(new Data { Category = "Lemon", Value = r.Next(20, 40) });
            return data;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.provider.Source = GenerateCollection();
        }
