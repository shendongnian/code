    protected void LinqDataSource_Inserted(object sender, LinqDataSourceStatusEventArgs e)
    {
        if (e.Exception == null)
        {
            Product newProduct = (Product)e.Result;
            // newProduct.ProductID is the new ID
        }
        else
        {
            // Some Exception - e.Exception.Message;
        }
    }
