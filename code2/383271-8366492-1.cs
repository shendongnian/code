     namespace MyApp.MyModel
     {
          public class MetaData : INotifyPropertyChanged
          {
               private StatusType status;
               public StatusType Status
               {
                    get { return status; }
                    set
                    {
                         if (status != value)
                         {
                              status = value;
                              NotifyPropertyChanged("Status");
                              NotifyPropertyChanged("StatusMessage");
                         }                
                    }
               }
               public string StatusMessage
               {
                    get { return ConvertStatusToSomethingMeaningful(status); }
               }
          ...
          }
     }
