    class LineItemVM : INotifyPropertyChanged{
    
      bool   m_loadingTriggered;
      string m_name="Loading...";
      string m_anotherProperty="Loading...";
    
      public string Name{
         get{
           TriggerLoadIfNecessary(); // Checks if data must be loaded
           return m_name;
         }
      }
   
      public string AnotherProperty{
         get{
           TriggerLoadIfNecessary(); // Checks if data must be loaded
           return m_anotherProperty;
         }
      }
      void TriggerLoadIfNecessary(){        
         if(!m_loadingTriggered){
           m_loadingTriggered=true;
           // This block will called before your item will be displayed
           //  due to the m_loadingTriggered-member it is called only once.
           //  Start here the asynchronous loading of the data
           //  This block is not called in virtualizing list, if the item
           //  is not visible to the user! 
           LoadAsync();
         }
      }
      ...
