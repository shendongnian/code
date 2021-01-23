            if (!IsPostBack)
            {
                //getData();
                cbxCategory.DataSource = CoffeeContext.tblProductTypes.ToList();
                cbxCategory.DataTextField = "Description";
                cbxCategory.DataValueField = "ProductType";
                cbxCategory.DataBind();
            }
        }
