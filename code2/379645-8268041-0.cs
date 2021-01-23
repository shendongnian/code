    public class YourViewmodel
    {
         //Other Variables
         
         
         public YourViewModelCtor()
         {
            Command1= new RelayCommand(Command1Func);
         }
         
         Public SelectedVar
         {
                 get {return value;}
                 Set { selectedVar=value;
                           OnPropertyChanged("SelectedVar");
                  }
         }
         //Other Properties
         void Command1Func(object obj)
         {
                  SelectedVar= obj as <Your Desired Type>;
                  //Do your thing with SelectedVar ... Do the same for Command2
         }
    }
