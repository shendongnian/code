    public partial class _Default : Page
    {
        List<ProductRates> ProductRateList = new List<ProductRates>() {
            new ProductRates(1,"Test",0),
            new ProductRates(2,"Test2",0),
            new ProductRates(3,"Test3",0)
        };
        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < ProductRateList.Count; i++)
            {
                double testing = ProductRateList[i].ProductOrderAmount;
                TextBox textBox = new TextBox();                
                textBox.Text = ProductRateList[i].ProductOrderAmount.ToString();
                textBox.ID = ProductRateList[i].ProductName + "TextBox";
                Button plusButton = new Button();               
                plusButton.Text = "+";
                plusButton.ID = ProductRateList[i].ProductName + "PinusButton";
                plusButton.Click += PlusButton_Click1;
                System.Web.UI.HtmlControls.HtmlGenericControl createButtonDiv =
                new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                createButtonDiv.ID = ProductRateList[i].ProductName + "createButtonDiv";
                createButtonDiv.Attributes.Add("class", "col-md-6");
                createButtonDiv.Controls.Add(plusButton);
                createButtonDiv.Controls.Add(textBox);              
                                  
                ProductPlaceholderDiv.Controls.Add(createButtonDiv);
                
            }
        }
        private void PlusButton_Click1(object sender, EventArgs e)
        {
            
            Button btn = (Button)sender;
            System.Web.UI.HtmlControls.HtmlGenericControl div = (System.Web.UI.HtmlControls.HtmlGenericControl)btn.Parent;
            string ProductName = btn.ID.Substring(0, btn.ID.Length - "PinusButton".Length);
            TextBox txt = (TextBox)div.FindControl(ProductName + "TextBox");           
            for (int i = 0; i < ProductRateList.Count; i++)
            {
                if (ProductRateList[i].TextBoxName == ProductName + "TextBox")
                {
                    ProductRateList[i].ProductOrderAmount = double.Parse(txt.Text) + 1;
                    txt.Text = ProductRateList[i].ProductOrderAmount.ToString();
                }
            }
            
        }
        public class ProductRates
        {            
            public ProductRates(int prodductId, string productName , double productOrderAmount  )
            {
                ProdductId = prodductId;
                ProductName = productName;
                ProductOrderAmount = productOrderAmount;
            }
            //Product
            public int ProdductId { get; set; }
            public string ProductName { get; set; }          
            public double ProductOrderAmount { get; set; }
            public string TextBoxName { get; set; }
        }
    }
