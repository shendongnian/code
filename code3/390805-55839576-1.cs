                    ExcelPackage EP = new ExcelPackage();
    
                    ExcelWorksheet Sheet = 
                    EP.Workbook.Worksheets.Add("subscriptions");
                    Sheet.Cells["A1"].Value = "Email";
                    Sheet.Cells["A1"].Style.Font.Bold = true;
        
                    Sheet.Cells["B1"].Value = "First Name";
                    Sheet.Cells["B1"].Style.Font.Bold = true;
        
                    Sheet.Cells["C1"].Value = "Middle Name";
                    Sheet.Cells["C1"].Style.Font.Bold = true;
        
                    Sheet.Cells["D1"].Value = "Last Name";
                    Sheet.Cells["D1"].Style.Font.Bold = true;
        
                    Sheet.Cells["E1"].Value = "Date Created";
                    Sheet.Cells["E1"].Style.Font.Bold = true;
        
                    Sheet.Cells["F1"].Value = "Subscribed";
                    Sheet.Cells["F1"].Style.Font.Bold = true;
        
                    var collection = MyRepository.GetSubscriptionsAll();
                    int row = 2;
                    foreach (var item in collection)
                    {
                        Sheet.Cells[string.Format("A{0}", row)].Value = item.Email;
                        Sheet.Cells[string.Format("B{0}", row)].Value 
      =item.FistName;
                        Sheet.Cells[string.Format("C{0}", row)].Value 
      =item.MiddleName;
                        Sheet.Cells[string.Format("D{0}", row)].Value 
      =item.LastName;
                        Sheet.Cells[string.Format("E{0}", row)].Value =   
           .DateCreated.ToString();
                        Sheet.Cells[string.Format("F{0}", row)].Value = 
       (item.Subscribed == false 
             ? "No" : "Yes"); ;
        
                        row++;
                    }
        
                    Sheet.Cells["A:AZ"].AutoFitColumns();
                    System.Web.HttpContext.Current.Response.Clear();
                    System.Web.HttpContext.Current.Response.ContentType = 
          "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    System.Web.HttpContext.Current.Response.AddHeader("content- 
      disposition", 
          "attachment: filename=" + "ListofSubscribers.xlsx");
                    
        System.Web.HttpContext.Current.Response.BinaryWrite(EP.GetAsByteArray());
                    System.Web.HttpContext.Current.Response.End();
                }
