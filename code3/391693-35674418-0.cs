     using (StreamReader sr = new StreamReader(path2))
            {
              string line;
                while ((line = sr.ReadLine()) != null)
                {             
                    dsnonhb.Tables[0].Columns.Add("InvoiceNum"  );
                    dsnonhb.Tables[0].Columns.Add("Odo"         );
                    dsnonhb.Tables[0].Columns.Add("PumpVal"      );
                    dsnonhb.Tables[0].Columns.Add("Quantity"    );
                    
                    DataRow myrow;
                    myrow = dsnonhb.Tables[0].NewRow();
                    myrow["No"] = rowcounter.ToString();
                    myrow["InvoiceNum"] = line.Substring(741, 6);
                    myrow["Odo"] = line.Substring(499, 6);
                    myrow["PumpVal"] = line.Substring(609, 7);
                    myrow["Quantity"] = line.Substring(660, 6);
