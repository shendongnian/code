    public partial class TestClassView : UserControl
    {
        public TestClassView()
        {
            InitializeComponent();
        }
    }
    <UserControl x:Class="Test.TestClassView" ...>
       <Grid>
          <TextBlock Text="{Binding Text}" />
       </Grid>
    </UserControl>
