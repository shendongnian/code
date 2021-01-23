    //example range
    Excel.Range rng = mWorkSheet.get_Range("A1", "H25");
    foreach (Excel.Range range in rng)
    {
        if (range.Value != null)
        {
            int number;
            bool isNumber = int.TryParse(range.Value.ToString().Trim(), out number);
            if (isNumber)
            {
                range.NumberFormat = "#,##0"; 
                range.Value = number;
            }
            else
            {
                //the percent values were decimals with commas in the string       
                string temp = range.Value.ToString();
                temp = temp.Replace(",", ".");
                range.Value = temp;
            }
        }
    }
