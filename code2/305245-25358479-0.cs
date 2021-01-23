            using (MyEntities ctx = new MyEntities())
            {
            
             
                var catRef = Convert.ToInt32(Request.QueryString["CategoryRef"]);
                var prodCounts = (
              from A in ctx.Products
              join B in ctx.ProductPrices
                  on A.ProductId equals B.ProductRef
              where A.CategoryRef == catRef
              group A by new { A.Name,B.ProductRef } into catGp
              select
                  new
                  {
                     catGp.Key.ProductRef,
                      catGp.Key.Name,
                      proIdCount = catGp.Count()
                  }).ToList();
                  Repeater1.DataSource = prodCounts;
                Repeater1.DataBind();
            }
