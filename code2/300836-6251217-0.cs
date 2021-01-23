            List<DT_Product> products = new List<DT_Product>();
            if (DDL_Order.SelectedIndex == 0) { 
                products = product.OrderByDescending(v => v.Sale_Price).ToList(); 
            } else if (DDL_Order.SelectedIndex == 1) {
                products = product.OrderBy(v => v.Sale_Price).ToList(); 
            }
            LV_Products.DataSource = products; 
            LV_Product.DataTextField = "ProductName"; 
            LV_Product.DataValueField = "ProductID";
            LV_Products.DataBind();
