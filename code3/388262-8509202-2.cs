    int orderId = 43680;
    using (AdventureWorksEntities context =
    new AdventureWorksEntities())
    {
    var order = (from o in context.SalesOrderHeaders
                 where o.SalesOrderID == orderId
                 select o).First();
    // Get ObjectStateEntry from EntityKey.
    ObjectStateEntry stateEntry =
        context.ObjectStateManager
        .GetObjectStateEntry(((IEntityWithKey)order).EntityKey);
    //Get the current value of SalesOrderHeader.PurchaseOrderNumber.
    CurrentValueRecord rec1 = stateEntry.CurrentValues;
    string oldPurchaseOrderNumber =
        (string)rec1.GetValue(rec1.GetOrdinal("PurchaseOrderNumber"));
    //Change the value.
    order.PurchaseOrderNumber = "12345";
    string newPurchaseOrderNumber =
        (string)rec1.GetValue(rec1.GetOrdinal("PurchaseOrderNumber"));
    // Get the modified properties.
    IEnumerable<string> modifiedFields = stateEntry.GetModifiedProperties();
    foreach (string s in modifiedFields)
        Console.WriteLine("Modified field name: {0}\n Old Value: {1}\n New Value: {2}",
            s, oldPurchaseOrderNumber, newPurchaseOrderNumber);
    // Get the Entity that is associated with this ObjectStateEntry.
    SalesOrderHeader associatedEnity = (SalesOrderHeader)stateEntry.Entity;
    Console.WriteLine("Associated Enity's ID: {0}", associatedEnity.SalesOrderID);
    }
