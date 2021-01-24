    if (dsRateDetails.Tables[0].Rows.Count > 0)
           {
               foreach (DataRow row in dsRateDetails.Tables[0].Rows)
               {
                   ProductRatesList.Add(new ProductRate
                   {
                       Rate = Convert.ToDecimal(row[0])
                   });
               }
               result.ProductRates = ProductRatesList;
               return result;
           }
