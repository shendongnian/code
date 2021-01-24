    public class CfgCountersViewModel : CfgCounters, INotifyPropertyChanged
    {
        public CfgCountersViewModel() 
        {
             // UpdateObcDatetimeCsv when obcDatetime changes
             obcDatetime.OnCollectionChanged += (sender, args) => 
             {
                  obcDatetimeCsv = String.Join(",", obcDatetime);
             }
        }
        ...
    }
