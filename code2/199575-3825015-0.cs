        public partial class MainWindow : Window
        {
    		public class SomeItem
    		{
    			public int[] Numbers { get; set; }
    			public string ChosenText { get; set; }
    		}
    		
    		private SomeItem item;
    		
            public MainWindow()
            {
                InitializeComponent();
    			this.item = new SomeItem{Numbers=new[]{7,8,10}, ChosenText="10"};
    			this.testStackPanel.DataContext = item;
            }
    
            private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
            {
            	MessageBox.Show(item.ChosenText);
            }
    	}
        <StackPanel VerticalAlignment="Center" x:Name="testStackPanel">
    		<ComboBox IsEditable="True" Width="100" ItemsSource="{Binding Numbers}" Text="{Binding ChosenText}"/>
    		<Button Content="Selected Value" Margin="0,10,0,0" Width="100" Click="Button_Click"/>
    	</StackPanel>
