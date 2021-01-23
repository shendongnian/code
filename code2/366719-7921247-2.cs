    public partial class ShippedOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.goFiles();
        }
        
        public void goFiles()
        {
            string[] array1 = Directory.GetFiles(@"C:\Kaplan\Replies\");
            string[] array2 = Directory.GetFiles(@"C:\Kaplan\Replies\", "*.REP");
            System.IO.StreamReader file = null;
            string line = "";
            bool hasLIFT = false;
            
            Response.Write("---Files:---<br/>");
            foreach (string name in array1)
            {
                file = new System.IO.StreamReader(@name);
                while((line = file.ReadLine()) != null)
                {
                    if(line.StartsWith("LIFT"))
                    {
                        hasLIFT = true;
                        break;
                    }
                 }
                 if(hasLIFT)
                 {
                     Response.Write("<span style=\"color:Red;\">" + name + "</span><br/>";
                     hasLIFT = false;
                 }
                 else
                     Response.Write(name + "<br/>";
            }
            //and can do the same for other array
        }
    }
