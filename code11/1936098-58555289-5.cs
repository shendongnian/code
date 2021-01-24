    public partial class Form1 : Form
    {
        #region Private Members
        /// <summary>
        /// The content list to bind to.
        /// </summary>
        private BindingList<Data> mData = null;
        /// <summary>
        /// The item to bind to.
        /// </summary>
        private BindingSource mDataSource = null;
        #endregion
        #region Constructor
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            // Get binding content
            mData = GetXmlData("data.xml");
            // Prepare the binding source from the read content
            mDataSource = new BindingSource(mData, null);
            // Set what is to be displayed
            comboBox1.DisplayMember = "Name";
            comboBox1.DataSource = mDataSource;
            // Bind textboxes
            tbName.DataBindings.Add(new Binding("Text", mDataSource, "Name", false, DataSourceUpdateMode.OnPropertyChanged));
            tbType.DataBindings.Add(new Binding("Text", mDataSource, "type", false, DataSourceUpdateMode.OnPropertyChanged));
            tbLiving.DataBindings.Add(new Binding("Text", mDataSource, "living", false, DataSourceUpdateMode.OnPropertyChanged));
        }
        #endregion
        /// <summary>
        /// Reads the provided XML file and puts it into a structured binding list.
        /// </summary>
        /// <returns></returns>
        private BindingList<Data> GetXmlData(string xmlFile)
        {
            // Create a data set and read the file
            var dataSet = new DataSet();
            dataSet.ReadXml(xmlFile);
            
            // Convert the content to a List<Data>
            var data = dataSet.Tables[0].AsEnumerable().Select(r => new Data
            {
                Name = r.Field<string>("Name"),
                Type = r.Field<string>("type"),
                Living = r.Field<string>("living")
            }).ToList();
            
            // Return the content as BindingList<Data>
            return new BindingList<Data>(data);
        }
    }
