     DataView dataView = new DataView(dt);
     foreach (DataRowView dataRow in dataView)
                {              
    
                    System.Diagnostics.Debug.WriteLine(DataBinder.Eval(dataRow, "AA").ToString());
                    System.Diagnostics.Debug.WriteLine(DataBinder.Eval(dataRow, "BB").ToString());
                    System.Diagnostics.Debug.WriteLine(DataBinder.Eval(dataRow, "CC").ToString());
    
                }
