    public SubViewModel SubAVM { 
       get { 
          return subAVM;
       }
       set{
       if (subAVM == value)
       {
          return;
       }
       subAVM = value; //implement the OnPropertyChanged ...
       }
    }
