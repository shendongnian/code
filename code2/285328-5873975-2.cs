    labels = (from item in result.AsEnumerable()//labels is of type workOrders
             select new workOrders
                    {
                        Items = new workOrdersWorkOrder[]
                        {
                            {
                                number = item.WorkOrder,
                                Part = item.Part,
                                Col3 = item.Col3,
                                Qty = item.Quantity.ToString()
                            }
                        }
                    }
               }).ToList();
