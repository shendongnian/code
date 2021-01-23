    foreach (var rec in context.ExecuteStoreQuery<DbDataRecord>("exec spGetProductsByGroup @ProductID={0}", product_id))
        {
    	for (var ri = 0; ri < rec.FieldCount;ri++)
    	{
            Console.WriteLine(rec.GetDataTypeName(ri)
                              +"   " + rec.GetName(ri)
                              +" = " + rec.GetValue(ri));
            }
        }
