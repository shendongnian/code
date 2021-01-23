     public IQueryable GetOrderDetails()
        { 
            var _db = new ProductContext();
            IQueryable<OrderDetail> query = _db.OrderDetails;
            if (ddlOrder.SelectedValue != null && ddlOrder.SelectedItem != null)
            {
                var id = Convert.ToInt32(ddlOrder.SelectedValue);
             
                query = query.Where(p => p.Username == User.Identity.Name && p.OrderId == id);
                    }   
           else{ query = null; ddlOrder.Visible = false;btnSubmit.Visible = false; }
            return query;
               }
