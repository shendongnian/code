        using System;
        using System.Collections.ObjectModel;
        using System.ComponentModel;
        using System.Windows;
        
        namespace YourNameSpace
        {
            public class MainWindowViewModel : INotifyPropertyChanged
            {
        
                public event PropertyChangedEventHandler PropertyChanged;
                public virtual void OnPropertyChanged(string propertyName)
                {
                    if (this.PropertyChanged != null)
                    {
                        this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                    }
                }
        
                private ObservableCollection<Ticket> _idlessTicketList;
                public ObservableCollection<Ticket> idlessTicketList
                {
                    get { return _idlessTicketList; }
                    set
                    {
                        _idlessTicketList = value;
                        OnPropertyChanged("idlessTicketList");
                    }
                }
    
                //Constructor
                public MainWindowViewModel()
                {
                    idlessTicketList = new ObservableCollection<Ticket>();
                }
    }
