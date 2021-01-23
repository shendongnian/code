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
    public partial class MenuExecutionDisplay : BaseUserControl
    {
        private readonly MyPictureListViewModel
            myPictureListViewModel;
        /// <summary>
        ///   MenuExecutionDisplay
        /// </summary>
        public MenuExecutionDisplay()
        {
            myPictureListViewModel= new MyPictureListViewModel();
            this.DataContext = myPictureListViewModel;
            InitializeComponent();
        }
    }
    <UserControl x:Class="OracleOfLegends.Roster"
                             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"      
                       xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"       
                      xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"                          xmlns:d="http://schemas.microsoft.com/expression/blend/2008"  
      
                          mc:Ignorable="d"   
                           d:DesignHeight="300"
     d:DesignWidth="300">         
           //Lots of goodies here. I would prefer to use ListView
           <ListView Name="myPicListView" ItemsSource={Binding PicList}>
                      <ListView.ItemTemplate>
                                            <Datatemplate>
                                                       //You fav control to display pic           
                                            </DataTemplate>
                      </ListView.ItemTemplate>
           </ListView> 
                      // Here i am just Displaying the name you can put any control you want
            <StackPanel DataContext="{Binding Path=SelectedItem,Elementname=myPicListView}">
            <TextBlock Text="{Binding Path=Name}"></TextBlock>
            </StackPanel>            </UserControl>  
