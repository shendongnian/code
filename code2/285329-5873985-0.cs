    labels = 
        new workOrders
        {
            Items = result.Select(o => new workOrder
                        {
                              number = o.WorkOrder,
                              Part = o.Part,
                              Col3 = o.Col3,
                              Qty = o.Quantity.ToString()
                        }).ToArray()
        };
