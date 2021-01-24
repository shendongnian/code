                ViewBag.TransactionAmount = users[i].TransactionAmount;
                ViewBag.CustomerName = users[i].CustomerName;
                // added constructor
                bdoToDb = new BdoToDb(); // <- don't know name of your class
                bdoToDb.CompanyCode = ViewBag.CompanyCode;
                bdoToDb.ProductCode = ViewBag.ProductCode;
