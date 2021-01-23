    public partial class One : System.Web.UI.Page , ISearch 
    {
        public    string SearchText
        {
            get
            {
                return TextBox1.Text;
            }
        }
    }
