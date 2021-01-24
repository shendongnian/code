      protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Cottages> list = new List<Cottages>();
                list.Add(new Cottages { MyText = "text1", MyValue = "value1" });
                list.Add(new Cottages { MyText = "text2", MyValue = "value2" });
                list.Add(new Cottages { MyText = "text3", MyValue = "value3" });
     
               ***BulletedList1.DataTextField = "MyText";***
                BulletedList1.DataSource = list;
                BulletedList1.DataBind();
            }
        }
        
    public class Cottages{
        public string MyValue { get; set; }
        public string MyText { get; set; }
    }
