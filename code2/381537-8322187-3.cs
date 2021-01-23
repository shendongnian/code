        public MyPictureListViewModel:INotifyPropertyChanged
        {
                ObservableCollection<MyPictureList> picList;
                public PicList
                {
                        get{return value;}
                        set{piclist=value;}
                        OnPropertyChanged("PicList")
                }
                //Fill the list with some methods... it depends on you
        }
    /// <summary>
    ///   Interaction logic for MyUserControl.xaml
    /// </summary>
    public partial class PicListDisplay
    {
        private readonly MyPictureListViewModel
            myPictureListViewModel;
        /// <summary>
        ///   PicListDisplay
        /// </summary>
        public PicListDisplay()
        {
            myPictureListViewModel= new MyPictureListViewModel();
            this.DataContext = myPictureListViewModel;
            InitializeComponent();
        }
    }
                I would prefer to use ListView
           <ListView Name="myPicListView" ItemsSource={Binding PicList}>
                      <ListView.ItemTemplate>
                                            <Datatemplate>
                                                       <UserControls:Roster/>           
                                            </DataTemplate>
                      </ListView.ItemTemplate>
           </ListView> 
                      // Here i am just Displaying the name you can put any control you want
            <StackPanel DataContext="{Binding Path=SelectedItem,Elementname=myPicListView}">
            <TextBlock Text="{Binding Path=Name}"></TextBlock>
            </StackPanel>            </UserControl>  
