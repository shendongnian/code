    DataTable dt1 = ConvertToDataTable(@"C:\Users\manchunl\Desktop\Sample1.txt", 10);
    DataTable dt2 = ConvertToDataTable2(@"C:\Users\manchunl\Desktop\Sample2.txt", 10);
    for (int i = 0; i < dt1.Rows.Count; i++)
    {
        DataRow dr1 = dt1.Rows[i];
    
        if (dt2.Rows.Count > i)
        {
            DataRow dr2 = dt2.Rows[i];
    
            string value1 = Convert.ToString(dr1["Column5"]);
            string value2 = Convert.ToString(dr2["Column5"]);
    
            if (!string.IsNullOrEmpty(value1) && !string.IsNullOrEmpty(value2) && value1 == value2)
            {
                Console.WriteLine(value1);
            }
            else
            {
                //Do code when no matched.
            }
        }
    }
