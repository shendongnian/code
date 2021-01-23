    <Button Command="{Binding CreateNewExaminationCommand, Source={x:Static viewmodel:ExaminationViewModel.Instance}}"></Button>
    // VIEWMODEL
        RelayCommand createNewExaminationCommand;
        public ICommand CreateNewExaminationCommand
        {
            get
            {
                if (createNewExaminationCommand== null)
                {
                    createNewExaminationCommand= new RelayCommand(param => this.CreateNew(),
                        param => this.CanCreateNew);
                }
                return createNewExaminationCommand;
            }
         }
         private ExaminationViewModel() {}
         private static readonly ExaminationViewModel instance = new ExaminationViewModel();
         public static ExaminationViewModel Instance
         {
               get {return instance;}
         }
