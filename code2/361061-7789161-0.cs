        protected void grd_sample_Sorting(object sender, GridViewSortEventArgs e)
        {
        var a = from c in sample_worker.get()
                    select new
                    {
                        c.CemID,
                        c.Title,
                        c.Description
                    };
    
            if(e.SortDirection=="ASC")
            {
                 if(e.SortExpression=="CemID")
                    a=a.OrderBy(x=>x.CemID);
                 else if (e.SortExpression=="Title")
                    a=a.OrderBy(x=>x.Title);
                 //And so on...
            }
            else 
            {
                 if(e.SortExpression=="CemID")
                    a=a.OrderByDescending(x=>x.CemID);
                 else if(e.SortExpression=="Title")
                    a=a.OrderByDescending(x=>x.Title);
                 //And so on...
            }
    
            grd_sample.DataSource = a;
            grd_sample.DataBind();
        }
