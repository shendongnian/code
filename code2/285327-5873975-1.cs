    labels = (from item in result.AsEnumerable()//labels is of type workOrders
             select new workOrders
                    {
                        Items = new workOrdersWorkOrder[]
                        {
                            {
                                number = o.WorkOrder,
                                Part = o.Part,
                                Col3 = o.Col3,
                                Qty = o.Quantity.ToString()
                            }
                        }
                    }
               }).ToList();
