    DataColumn Min_Weight = new DataColumn("Min_Weight");
    Min_Weight.DataType = System.Type.GetType("System.Decimal");
    MITTRA.Columns.Add(Min_Weight);
    Decimal Sum = Convert.ToDecimal(MITTRA.Compute("SUM(Min_Weight)", string.Empty));
    MaxTol.Text = Sum.ToString(); // This Works finally. 
