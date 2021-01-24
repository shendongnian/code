    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Input;
    
    namespace ComboTreeBinding
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                DataContext = new OrgTreeViewModel();
            }
        }
    
        public class OrgTreeViewModel: INotifyPropertyChanged
        {
            public OrgTreeViewModel()
            {
                this.CreateDataList();
            }
            public ObservableCollection<OrgElementViewModel> List { get; set; }
            private List<OrgElementViewModel> root;
            public List<OrgElementViewModel> Root
            {
                get
                {
                    if (root == null) root = new List<OrgElementViewModel>{List[0]};
                    return root;
                }
            }
    
            public void CreateDataList()
            {
                ObservableCollection<OrgElementViewModel> list = new ObservableCollection<OrgElementViewModel>();
                list.Add(new OrgElementViewModel("1", "AAAAA", "0"));
                list.Add(new OrgElementViewModel("2", "BBBBB", "1"));
                list.Add(new OrgElementViewModel("3", "CCCCC", "1"));
                list.Add(new OrgElementViewModel("7", "DDDDD", "2"));
                this.List = list;
                foreach (OrgElementViewModel item in list) SetChildren(item);
            }
    
            private void SetChildren(OrgElementViewModel Parent)
            {
                foreach (OrgElementViewModel listItem in List)
                {
                    if (listItem.ParentId == Parent.Id) Parent.Children.Add(listItem);
                }
            }
    
            private ICommand selectedCommand;
            public ICommand SelectedCommand
            {
                get
                {
                    if (selectedCommand == null)
                    {
                        selectedCommand = new CommandBase(i => this.SetSelected(i), null);
                    }
    
                    return selectedCommand;
                }
            }
    
            private void SetSelected(object orgElement)
            {
                this.Selected = orgElement as OrgElementViewModel;
                SelectedId = this.Selected.Id;
    
                OnPropertyChanged("SelectedId");
    
            }
    
            private OrgElementViewModel selected;
            public OrgElementViewModel Selected
            {
                get { return selected; }
                set
                {
                    selected = value;
                    selected.IsSelected = true;
                    //ShowChildrenLevel();  //show only the levels chosen by the user
                    OnPropertyChanged("Selected");
                }
            }
    
            private string selectedId;
            public string SelectedId
            {
                get { return selectedId; }
                set
                {
                    selectedId = value;
                    OrgElementViewModel orgElementViewModel = FindById(selectedId);
                    if (orgElementViewModel != null) this.Selected = orgElementViewModel;
                    OnPropertyChanged("SelectedId");
                }
            }
    
            private OrgElementViewModel FindById(string ID)
            {
                foreach(OrgElementViewModel item in this.List)
                {
                    if (item.Id == ID) return item;
                }
                return null;
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        public class OrgElementViewModel: INotifyPropertyChanged
        {
            public string Id { get; set; }
            public string FirstName { get; set; }
            public string ParentId { get; set; }
            private bool isSelected;
            public ObservableCollection<OrgElementViewModel> Children { get; set; }
            public OrgElementViewModel(string Id, string FirstName, string ParentId)
            {
                this.Id = Id;
                this.FirstName = FirstName;
                this.ParentId = ParentId;
                this.Children = new ObservableCollection<OrgElementViewModel>();
            }
    
            public bool IsSelected
            {
                get { return isSelected; }
                set
                {
                    isSelected = value;
                    OnPropertyChanged("IsSelected");
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        public class CommandBase : ICommand
        {
            private Action<object> commandDelegate;
            private object commandParameter;
    
            public CommandBase(Action<object> commandDelegate, object commandParameter)
            {
                this.commandDelegate = commandDelegate;
                this.commandParameter = commandParameter;
            }
    
            public event EventHandler CanExecuteChanged;
    
            public bool CanExecute(object parameter) => true;
            public void Execute(object parameter)
            {
                commandDelegate?.Invoke(parameter);
            }
        }
    }
