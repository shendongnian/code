    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections.ObjectModel;
    namespace WpfApplication1
    {
        class Downloads : NotifyBase
        {
            public virtual ObservableCollection<DownloadedItem> DownloadedItemCollection
            {
                get { return _DownloadedItemCollection; }
                set { _DownloadedItemCollection = value; OnPropertyChanged(System.Reflection.MethodBase.GetCurrentMethod().Name.Substring(4));	/*OnPropertyChanged("DownloadedItemCollection");*/ }
            } private ObservableCollection<DownloadedItem> _DownloadedItemCollection;
        
        }
    }
    public class NotifyBase : INotifyPropertyChanged
    {
        #region NotifyBase
        // Declare the event
        public virtual event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
