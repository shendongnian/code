    namespace Demos.StackOverflow.MasterPages
    {
        using System;
        // Here, we inherits from PageWithStatus, not from Page.
        public partial class ProductsPage : PageWithStatus
        {
            protected void Page_Load(object sender, EventArgs e)
            {
            }
            protected void BuyButton_Click(object sender, EventArgs e)
            {
                this.ChangeStatus("The product is purchased.");
            }
            protected void SellButton_Click(object sender, EventArgs e)
            {
                this.ChangeStatus("The product is sold.");
            }
        }
    }
