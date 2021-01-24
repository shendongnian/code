      public MainWindowViewModel()
      {
         // Add available pages and set page
         PageViewModels.Add(new UserControl1ViewModel());
         PageViewModels.Add(new UserControl2ViewModel());
 
         CurrentPageViewModel = PageViewModels[0];
 
         //Mediator.Subscribe("GoTo1Screen", OnGo1Screen);
         //Mediator.Subscribe("GoTo2Screen", OnGo2Screen);
      }
