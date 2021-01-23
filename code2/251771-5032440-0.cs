    public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			
			var binding = new Binding("Text", this, "Size", false, DataSourceUpdateMode.OnPropertyChanged);
			binding.Format += new ConvertEventHandler(binding_Format);
			label1.DataBindings.Add(binding);
		}
		void binding_Format(object sender, ConvertEventArgs e)
		{
			if (e.Value is Size)
			{
				e.Value = ((Size)e.Value).Width.ToString();
			}
		}
	}
