            db_class Connstring = new db_class();
            try
            {
                DataTable dt = (DataTable)HttpContext.Current.Session["aaa"];
                if (dt == null)
                {
                    DataTable dtable = new DataTable();
                    dtable.Clear();
                    dtable.Columns.Add("ProductID");// Add new parameter Here
                    dtable.Columns.Add("Price");
                    dtable.Columns.Add("Quantity");
                    dtable.Columns.Add("Total");
                    object[] trow = { ProductID, Price, Quantity, Total };// Add new parameter Here
                    dtable.Rows.Add(trow);
                    HttpContext.Current.Session["aaa"] = dtable;                   
                }
                else
                {
                    object[] trow = { ProductID, Price, Quantity, Total };// Add new parameter Here
                    dt.Rows.Add(trow);
                    HttpContext.Current.Session["aaa"] = dt;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
