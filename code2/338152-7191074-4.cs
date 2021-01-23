    namespace Test
    {
        public partial class Form2 : Form
        {
            BindingSource productbindingsource;
            var productsbycount;
    
            public Form2()
            {
                InitializeComponent();
                Load += new EventHandler(Form2_Load);
            }
    
            void Form2_Load(object sender, EventArgs e)
            {
                productsbycount = abc.products.GroupBy(x => x.product_Id).Select(a => new
                {
                    productid = a.Key,
                    prouctnam = a.FirstOrDefault().product_Name,
                    productimage = a.FirstOrDefault().product_Image,
                    productdescr = a.FirstOrDefault().product_Description,
                    stockavailable = a.LongCount(),
                    productprice = a.FirstOrDefault().product_Price
                });
                productbindingsource.DataSource = productsbycount;
                productgridview.DataSource = productbindingsource;
                DataGridViewButtonColumn buttoncolumn = new DataGridViewButtonColumn();
                productgridview.Columns.Add(buttoncolumn);
                buttoncolumn.Text = "Buy";
                buttoncolumn.HeaderText = "Buy";
                buttoncolumn.UseColumnTextForButtonValue = true;
                buttoncolumn.Name = "btnbuy";
                productgridview.Columns[0].Visible = false;
            }
    
            private void methodNameHere()
            {
                productsbycount = abc.products.GroupBy(x => x.product_Id).Where(a => a.FirstOrDefault().product_Price > 0 && a.FirstOrDefault().product_Price <= 1000)
                                  .Select(a => new
                                  {
                                      productid = a.Key,
                                      prouctnam = a.FirstOrDefault().product_Name,
                                      productimage = a.FirstOrDefault().product_Image,
                                      productdescr = a.FirstOrDefault().product_Description,
                                      stockavailable = a.LongCount(),
                                      productprice = a.FirstOrDefault().product_Price
                                  });
    
                productbindingsource.ResetBindings(false);
            }
        }
    }
