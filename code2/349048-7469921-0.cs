    public class Data
        {
            public int? Column2Data { get; set; }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
    
                List<Data> list = new List<Data>()
                {
                     new Data(){ Column2Data=10100},
                     new Data(){},
                     new Data(){ Column2Data=4000}
                };
                Repeater1.DataSource = list;
                Repeater1.DataBind();
            }
        }
 
