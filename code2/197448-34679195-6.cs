    <!--XAML-->
    <ComboBox x:Name="ComboBoxFrom"
        SelectedValue="{Binding FilterService.TripLengthFrom, Mode=TwoWay}" />
    // Code behind
    public partial class FilterView : UserControl
    {
    	public FilterView()
    	{
    	    this.InitializeComponent();
    	
    	    this.ComboBoxFrom.SelectedValuePath = "Key";
    	    this.ComboBoxFrom.DisplayMemberPath = "Value";
    	    this.ComboBoxFrom.Items.Add(new KeyValuePair<int, string>(0, "0"));
    	    this.ComboBoxFrom.Items.Add(new KeyValuePair<int, string>(30, "30"));
    	    this.ComboBoxFrom.Items.Add(new KeyValuePair<int, string>(50, "50"));
    	    this.ComboBoxFrom.Items.Add(new KeyValuePair<int, string>(100, "100"));
    	}
