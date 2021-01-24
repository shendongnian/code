    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows;
    
    namespace Nachbestellungen
    {
        public class vorhandeneNachbestellungenViewModel : INotifyPropertyChanged
        {
         
            public event PropertyChangedEventHandler PropertyChanged;
            public virtual void OnPropertyChanged(string propertyName)
            {
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
    
            private ObservableCollection<Nachbestellung> _collTop;
            public ObservableCollection<Nachbestellung> CollTop
            {
                get { return _collTop; }
                set
                {
                    _collTop = value;
                    OnPropertyChanged("CollTop");
                }
            }
    
            private ObservableCollection<Artikel> _collBot;
            public ObservableCollection<Artikel> CollBot
            {
                get { return _collBot; }
                set
                {
                    _collBot = value;
                    OnPropertyChanged("CollBot");
                }
            }
    
            private Nachbestellung _selItem; 
            public Nachbestellung SelItem
            {
                get { return _selItem; }
                set
                {
                    _selItem = value;
                    OnPropertyChanged("SelItem");
                }
            }
    
            public vorhandeneNachbestellungenViewModel(string hv)
            {
                try
                {             
                    //connecting to database
                    var crud = new MongoCRUD("avdb");
                    //get filtered records (filtered by Id which is "Hv": hv)            
                    var erg = crud.LoadRecords<Nachbestellung>("nachbestellungen", hv);
                    //filtered List is an ObservableCollection which is updated with OnPropertyChanged method
                    CollTop = new ObservableCollection<Nachbestellung>(erg);
                    
                    //same procedure for the articles collection.... 
                    //var arterg = crud.LoadRecords<Artikel>("bestellteArtikel", hv);
                    CollBot = new ObservableCollection<Artikel>();
    
                    for (int i = 0; i < CollTop.Count; i++)
                    {
                        foreach (var a in CollTop[i].artikelliste)
                        {
                            CollBot.Add(a);
                        }                   
                    }
                 
                    //wenn Abfrageergebnis null ist, dann Messagebox-Info (Zu dieser Hv wurde keine Nachbestellung gefunden!)
                    if (CollBot.Count <= 0)
                    {
                        MessageBox.Show("Zu dieser Hv wurde keine Nachbestellung gefunden!",
                            "Keine Daten vorhanden!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }           
        }
    }
