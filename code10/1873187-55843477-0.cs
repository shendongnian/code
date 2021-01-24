     <ContentPage.Content>
        <StackLayout>
            <ListView
                x:Name="mylistview"
                ItemsSource="{Binding lists}"
                SelectedItem="{Binding selecteditem}">
                <ListView.ItemTemplate>
                    <DataTemplate>
                        <ViewCell>
                            <ViewCell.ContextActions>
                                <MenuItem
                                    Command="{Binding BindingContext.DeletePlaylistCommand, Source={x:Reference Name=mylistview}}"
                                    IsDestructive="true"
                                    Text="Delete Item" />
                                <MenuItem
                                    Command="{Binding BindingContext.EditPlaylistCommand, Source={x:Reference Name=mylistview}}"
                                    IsDestructive="true"
                                    Text="Edit Item" />
                            </ViewCell.ContextActions>
                            <StackLayout Padding="15,0">
                                <Label Text="{Binding Title}" />
                            </StackLayout>
                        </ViewCell>
                    </DataTemplate>
                </ListView.ItemTemplate>
            </ListView>
        </StackLayout>
    </ContentPage.Content>
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page19 : ContentPage, INotifyPropertyChanged
    {
        public ObservableCollection<Playlist> lists { get; set; }
        //public RelayCommand1 AddPlaylistCommand { get; set; }
        public RelayCommand DeletePlaylistCommand { get; set; }
        public RelayCommand EditPlaylistCommand { get; set; }
        private Playlist _selecteditem;
        public Playlist selecteditem
        {
            get { return _selecteditem; }
            set
            {
                _selecteditem = value;
                RaisePropertyChanged("selecteditem");
            }
        }
        public Page19 ()
		{
			InitializeComponent ();
            lists = new ObservableCollection<Playlist>()
            {
                new Playlist(){Id=1,Title="list 1"},
                 new Playlist(){Id=2, Title="list 2"},
                  new Playlist(){Id=3,Title="list 3"},
                   new Playlist(){Id=4,Title="list 4"},
                    new Playlist(){Id=5,Title="list 5"},
                    new Playlist(){Id=6,Title="list 6"},
            };
            DeletePlaylistCommand = new RelayCommand(DeletePlaylist);
            EditPlaylistCommand = new RelayCommand(EditPlaylist);
            selecteditem = lists[0];
            this.BindingContext = this;
		}
        public void AddPlaylist()
        {
            
        }
        public void DeletePlaylist()
        {
            Playlist item = selecteditem;
            lists.Remove(item);
        }
        public void EditPlaylist()
        {
            Playlist item = selecteditem;
            int id = item.Id;
            foreach(Playlist playl in lists.Where(a=>a.Id==id))
            {
                playl.Title = "chenge title";
            }
        }
      
        public event PropertyChangedEventHandler PropertyChanged;
        
        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    public class Playlist: INotifyPropertyChanged
    {
        private int _Id;
        public int Id
        {
            get { return _Id; }
            set
            {
                _Id = value;
                RaisePropertyChanged("Id");
            }
        }
        private string _Title;
        public string Title
        {
            get { return _Title;}
            set
            {
                _Title = value;
                RaisePropertyChanged("Title");
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
