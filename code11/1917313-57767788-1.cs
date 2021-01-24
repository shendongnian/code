    public partial class MainWindow : Window
    {    
      public ObservableCollection<ListObj> MainList { get; set; }
      public MainWindow()
      {
        InitializeComponent();
    
        MainList1 = new ObservableCollection<ListObj>
        {
          new ListObj
          {
            Key="key1", Value="value1",
            SubList=new ObservableCollection<SubListObj>
            {
              new SubListObj{id="subid1", name="subname1" },
              new SubListObj{id="subid2", name="subname2" }
            }
          },
          new ListObj
          {
            Key="key2", Value="value2",
            SubList=new ObservableCollection<SubListObj>
            {
              new SubListObj{id="subid3", name="subname3" }
            }
          }    
        };
      }    
    }
