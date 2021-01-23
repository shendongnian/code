    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Item> list = new List<Item>();
            list.Add(new Item() { ImageURL = "~/sample.jpg", Title = "samsung galaxy" });
            list.Add(new Item() { ImageURL = "~/sample.jpg", Title = "ipad" });
            list.Add(new Item() { ImageURL = "~/sample.jpg", Title = "xoom" });
            ListView1.DataSource = list;
            ListView1.DataBind();
        }
    }
    
    public class Item
    {
        public string ImageURL { get; set; }
        public string Title { get; set; }
    }
