         public ActionResult SaveOrder(Order[] requesting)
        {
            string result = "Error! Order Is Not Complete!";
            using (mymodel dbb = new mymodel())
            {
                var customerId = Guid.NewGuid();
                Ordering ord = new Ordering();
                ord.CustomerId = customerId;
                ord.date_order_placed = DateTime.Now;
                dbb.Orderings.Add(ord);
               
                if (dbb.SaveChanges() > 0)
                {
                  
                    string order_id = dbb.Orderings.Max(o => o.invoice_number);
                    foreach(var item in requesting)
                    {
                        Invoice_Line_Items in_l_i = new Invoice_Line_Items();
                            in_l_i.invoice_number = order_id;
                            in_l_i.department = item.depart;
                            in_l_i.service = item.Service;
                            in_l_i.gender = item.Gender;
                            in_l_i.item = item.Item;
                            in_l_i.quantity = item.Quantity;
                            in_l_i.price = item.price;
                        
                        dbb.Invoice_Line_Items.Add(in_l_i);
                    }
                    
                    if (dbb.SaveChanges() > 0)
                    {
                        result = "Success! Order Is Complete!";
                       
                    }
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
