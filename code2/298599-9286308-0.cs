        public MyViewModel LoadData()
        {
            MyViewModel viewModel = null;
            try
            {
                Task.Factory.StartNew(() =>
                   {
                       var task1 = Task<MyViewModel>.Factory.StartNew(() =>
                       {
                           return BuildMyViewModel(args);
                       });
                       var task2 = Task<ViewModel2>.Factory.StartNew(() =>
                       {
                           return BuildViewModel2(args);
                       });
                       var task3 = Task<ViewModel3>.Factory.StartNew(() =>
                       {
                           return BuildViewModel3(args);
                       });
                       Task.WaitAll(task1, task2, task3);
                       viewModel = task1.Result;
                       viewModel.ViewModel2 = task2.Result;
                       viewModel.ViewModel3 = task3.Result;
                   }).Wait();
            }
            catch (AggregateException ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.StackTrace); 
                // ...
            }
            return viewModel;
        }
