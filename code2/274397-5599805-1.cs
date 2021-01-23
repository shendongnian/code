    class LineItemVM : INotifyPropertyChanged{
    
      string m_name="Loading...";
    
      public string Name{
         get{
           TriggerLoadIfNecessary();
           return m_name;
         }
      }
    
      void TriggerLoadIfNecessary(){
         if(!DataLoadedOrLoading){
           LoadAsync();
         }
      }
      ...
