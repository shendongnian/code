     public override void DataBind()
     {
           AppProduct product = (Page.GetDataItem() as AppProduct);
           lbl_title.Text = product.Title;
           lbl_short.Text = product.Short;
           lbl_date.Text = product.Date.ToShortDateString();                       
           img_product.src= "\"data:image/jpg;base64,"+System.Convert.ToBase64String(product.Image1)+"\"";
            base.DataBind();
     }
