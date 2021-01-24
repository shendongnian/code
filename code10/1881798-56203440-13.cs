    public class MyData_ViewModel : INotifyPropertyChanged
    {
       public event PropertyChangedEventHandler PropertyChanged;
       public void RaisePropertyChanged(string propertyName)
       {
          if (PropertyChanged != null)
             PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
       }
    
       public void LoadingMyDataAndView()
       {
          // Controller I use to get whatever data I need from ex: SQL
          _myDataModel = new MyDataModel();
    
          // the view / window / control I want to present to users
          _myView = new MyView();
    
          // Now, set the data context on the view to THIS ENTIRE OBJECT.
          // Now, anything on THIS class made as public can be have a binding
          // directly to the control in the view.  Since the DataContext is 
          // set here, I can bind to anything at this level or lower that is public.
          _myView.DataContext = this;
       }
    
       private MyView _myView;
       private MyDataModel _myDataModel;
    
       // such as example exposed property
       public string SomeThingYouWantToExpose {get; set; }
    
       public void GettingSomeData()
       {
          var something = _myDataModel.GetSomeData();
    
          // … doing something to get / prepare / whatever...
          SomeThingYouWantToExpose = "some new label";
          // Now raise which the view bound to this property will updated itself
          RaisePropertyChanged( "SomeThingYouWantToExpose" );
       }
    }
