      PropertyInfo[] Properties = typeof(InvoiceLineItemSummary).GetProperties();     
    
                foreach (PropertyInfo objProperty in Properties)
                {
                        if (columns.ConvertAll(column=>column.ToLower()).Contains(objProperty.Name.ToLower()))
                        {
                            if (Nullable.GetUnderlyingType(objProperty.PropertyType) != null)
                            {
                                if (Nullable.GetUnderlyingType(objProperty.PropertyType).ToString() == "System.Decimal")
                                    vm.InvoiceLineItemSummaries.ToList().ForEach(val => val.GetType().GetProperty(objProperty.Name).SetValue(val,  Math.Round(Convert.ToDecimal(val.GetType().GetProperty(objProperty.Name).GetValue(val, null)), 2), null));
                                
                            }
                            else if(objProperty.PropertyType.ToString() == "System.Decimal")
                                vm.InvoiceLineItemSummaries.ToList().ForEach(val => val.GetType().GetProperty(objProperty.Name).SetValue(val, Math.Round(Convert.ToDecimal(val.GetType().GetProperty(objProperty.Name).GetValue(val, null)), 2), null));
                        }  
                }
    
    
    //vm.InvoiceLineItemSummary is List of classobject
    //InvoiceLineItemSummary is class
