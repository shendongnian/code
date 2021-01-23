    namespace WebApplication1
    {
        public partial class _Default : System.Web.UI.Page
        {
            private Dictionary<string, object> myDictionary;
    
            protected void Page_Load(object sender, EventArgs e)
            {
                myDictionary = new Dictionary<string, object>();
                myDictionary.Add("test", "Some Test String as Object");
            }
    
            protected void TextBox1_TextChanged(object sender, EventArgs e)
            {
                myDictionary.Add("TextBox1Value", TextBox1.Text);
            }
    
            protected void Button1_Click(object sender, EventArgs e)
            {
                TextBox1.Text = myDictionary["test"].ToString();
            }
        }
    }
