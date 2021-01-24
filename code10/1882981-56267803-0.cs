    public class CustomObject
        {
            public int ID { get; set; }
            public string Name { get; set; }
            
            public CustomObject(int _ID,string _Name)
            {
                this.ID = _ID;
                this.Name = _Name;
            }
        }
        public partial class WebForm1 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                List<CustomObject> customList = new List<CustomObject>();
                customList.Add(new CustomObject(1,"test1"));
                customList.Add(new CustomObject(2,"test2"));
                myDropDownList.DataSource = customList.Select(x => new { x.Name, Value = x.ID });
                myDropDownList.DataTextField = "Name";
                myDropDownList.DataValueField = "Value";
                myDropDownList.DataBind();
            }
        }
