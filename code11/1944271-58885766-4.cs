      public ICommand ClickMeCommand
        {
            get
            {
                if (_clickMeCommand == null)
                    _clickMeCommand = new RelayCommand<SomeItem>(DoSomething);
                return _clickMeCommand;
            }
        }
         private void DoSomething(SomeItem obj)
        {
            //Note that here you can manipulate the "obj" any way you want.
            //This "obj" is excacly that one was clicked
            obj.ClickCount++;
            ClickedText = $"ID: [{obj.AnimalId}] - Animal: [{obj.AnimalName}] {Environment.NewLine} ClickCount:[{obj.ClickCount}]";
        }
