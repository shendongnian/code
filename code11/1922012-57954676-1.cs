    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace WpfApp6
    {
        class ViewModel : BaseViewModel
        {
            private string myProperty1;
            private string myProperty2;
            private bool isMyProperty2Visible = false;
            private ObservableCollection<string> myCollection = new ObservableCollection<string>();
    
            public ObservableCollection<string> MyCollection
            {
                get
                {
                    return myCollection;
                }
                set
                {
                    if (value != myCollection)
                    {
                        myCollection = value;
                        RaisePropertyChanged("MyCollection");
                    }
                    
                }
            }
    
    
            public RelayCommand AddElement { get; }
            public RelayCommand AddListItem { get; }
    
            public ViewModel()
            {
                AddElement = new RelayCommand(OnAddElement, CanAddElement);
                AddListItem = new RelayCommand(OnAddListItem, CanAddListItem);
            }
    
            private bool CanAddListItem()
            {
                return true;
            }
    
            private void OnAddListItem()
            {
                MyCollection.Add("NewItem");
            }
    
            private bool CanAddElement()
            {
                return true;
            }
    
            private void OnAddElement()
            {
                IsMyProperty2Visible = true;
            }
    
            public bool IsMyProperty2Visible
            {
                get
                {
                    return isMyProperty2Visible;
                }
                set
                {
                    if (value != isMyProperty2Visible)
                    {
                        isMyProperty2Visible = value;
                        RaisePropertyChanged("IsMyProperty2Visible");
                    }
                }
            }
    
            public string MyProperty1
            {
                get
                {
                    myProperty1 = "Property1";
                    return myProperty1;
                }
                set
                {
                    if (value != myProperty1)
                    {
                        myProperty1 = value;
                        RaisePropertyChanged("MyProperty1");
                    }
                    
                }
            }
    
            public string MyProperty2
            {
                get
                {
                    myProperty2 = "Property2";
                    return myProperty2;
                }
                set
                {
                    if (value != myProperty2)
                    {
                        myProperty2 = value;
                        RaisePropertyChanged("MyProperty2");
                    }
                }
            }
        }
    }
