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
                              statusMessage = ConvertStatusToSomethingMeaningful(value);
                              NotifyPropertyChanged("Status");
                              NotifyPropertyChanged("StatusMessage");
                         }                
                    }
               }
               private string statusMessage;
               public string StatusMessage
               {
                    get { return ConvertStatusToSomethingMeaningful(status); }
               }
          ...
          }
     }
