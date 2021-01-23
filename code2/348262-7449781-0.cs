    public partial class Combine : Telerik.WinControls.UI.RadForm
    {
        public static string Thepath { get; set; }
        public static string TheFirstFile { get; set; }
        public string[] files = null;
        public Combine()
        {
            InitializeComponent();
        }
        private void Combine_Load(object sender, EventArgs e)
        {
            
        }
        private void radButton1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textBox1.Text = folderBrowserDialog1.SelectedPath;
            Thepath = folderBrowserDialog1.SelectedPath + @"\";
            string[] files = Directory.GetFiles(folderBrowserDialog1.SelectedPath);
            radLabel1.Text = "Number of Files to Combine: " + files.Length.ToString();
            TheFirstFile = files[0];
            
        }
        private void combineButton_Click(object sender, EventArgs e)
        {
            ExcelEngine.CombineWorkBooks(Thepath, "*.xls", Thepath, false, TheFirstFile);
        }
    }
    
