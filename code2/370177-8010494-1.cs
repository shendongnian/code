    public partial class Demo : System.Web.UI.Page
    {
        private DataTable _myData = null;
        protected DataTable MyData
        {
            get
            {
                if (null == _myData)
                {
                    // You would load your data here.
                    _myData = new DataTable();
                }
                return _myData;
            }
        }
    
        protected void Page_Load(object sender, EventArgs e)
        {
            // Lets say you set your data source here
            myGrid.DataSource = this.MyData;
        }
    
        protected void Rendering(object sender, EventArgs e)
        {
            // This is some other event that also needs to get at the data.
            DataTable mydata = this.MyData;
        }
    
        protected void Unload(object sender, EventArgs e)
        {
            if (null != _myData)
            {
                _myData.Dispose();
                _myData = null;
            }
        }
