    namespace ComboBoxDataGrid
    {
        public class TestClass
        {
            static TestClass()
            {
                ChoiseData = new List<string>();
                ChoiseData.Add("Yes");
                ChoiseData.Add("No");
                ChoiseData.Add("Maybe");
            }
            public static List<string> ChoiseData
            {
                get;
                set;
            }
            public TestClass()
            {
                SelectedChoise = string.Empty;
            }
            public TestClass(string selectedChoise)
            {
                SelectedChoise = selectedChoise;
            }
            public string SelectedChoise
            {
                get;
                set;
            }
        }
    }
    public partial class WinWorkers: Window
    {
        public WinWorkers()
        {
            InitializeComponent();
            TestClasses = new ObservableCollection<TestClass>();
            TestClasses.Add(new TestClass("Yes1"));
            TestClasses.Add(new TestClass("No"));
            TestClasses.Add(new TestClass("Maybe"));
            c_dataGrid.ItemsSource = TestClasses;
        }
        public ObservableCollection<TestClass> TestClasses
        {
            get;
            set;
        }
    }
    <Window x:Class="ComboBoxDataGrid.WinWorkers"
            xmlns:local="clr-namespace:ComboBoxDataGrid"
            ...>
        <Window.Resources>
            <local:TestClass x:Key="TestClass" />
        </Window.Resources>
        <Grid>
            <DataGrid Name="c_dataGrid"
                      AutoGenerateColumns="False"
                      RowHeaderWidth="100">
                <DataGrid.Columns>
                    <DataGridComboBoxColumn Header="Choise_StaticList"
                                            SelectedValueBinding="{Binding SelectedChoise}"
                                            ItemsSource="{Binding Source={StaticResource TestClass}, Path=ChoiseData}"/>
                </DataGrid.Columns>
            </DataGrid>
        </Grid>
    </Window>
