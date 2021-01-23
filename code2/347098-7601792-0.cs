    enter code here
    protected void ODSProducts_Updated(object sender, ObjectDataSourceStatusEventArgs e)
        {
            if (e.Exception != null)
            {
                if (((e.Exception.InnerException).InnerException).Message.Contains("Cannot insert duplicate key row"))
                {
                    RadWindowManager.RadAlert("Duplicate Product, Enter a new Product", 330, 100, "Insert Error", "");
                    e.ExceptionHandled = true;
                }
            }
        }
 
