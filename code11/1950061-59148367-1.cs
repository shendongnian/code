    using Address_Manager.Model;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace Address_Manager.ViewModel
    {
        class StoreAddressViewModel : BindableBase
        {
            public StoreAddressViewModel()
            {
                LoadStores();
            }
    
            public ObservableCollection<StoreAddress> _StoreDetails = new ObservableCollection<StoreAddress>();
            public ObservableCollection<StoreAddress> StoreDetails
            {
                get
                {
                    return _StoreDetails;
                }
                set
                {
                    _StoreDetails = value;
                    OnPropertyChanged();
                }
            }
            public ObservableCollection<string> _Stores = new ObservableCollection<string>();
            public ObservableCollection<string> Stores
            {
                get
                {
                    return _Stores;
                }
                set
                {
                    _Stores = value;
                    OnPropertyChanged();
                }
            }
    
            public void LoadStores()
            {
                StoreDetails.Clear();
                Stores.Clear();
    
                string addressRepository = ConfigurationManager.AppSettings["ReferenceFilePath"];
    
                if(!string.IsNullOrWhiteSpace(addressRepository) && File.Exists(addressRepository))
                {
                    List<string> rawStoreData = new List<string>();
                    rawStoreData = File.ReadAllLines(addressRepository).ToList();
                    foreach (string line in rawStoreData)
                    {
                        string[] segments = line.Split(',');
                        StoreAddress store = new StoreAddress
                        {
                            StoreCode = segments[0],
                            StoreName = segments[1],
                            Address1 = segments[2],
                            Address2 = segments[3],
                            City = segments[4],
                            State = segments[5],
                            PostCode = segments[6],
                            Country = segments[7],
                            Phone = segments[8],
                            Email = segments[9],
                            Manager = segments[10],
                            AreaManager = segments[11],
                            OpeningHours = segments[12].Split('|').ToList()
                        };
                        StoreDetails.Add(store);
                        Stores.Add(store.StoreName);
                    }
                }
            }
    
        }
    }
