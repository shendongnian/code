    try
    {
        string dob = tbStartDate.Text;
        DateTime dv = DateTime.Parse(dob);
        string format1 = dv.ToString("yyyy-MM-dd");
        string dob2 = tbEndDate.Text;
        DateTime dt2 = DateTime.Parse(dob2);
        string format2 = dt2.ToString("yyyy-MM-dd");
    }
    catch (System.FormatException)
    {
        MessageBox.Show("pls enter valid date format");
    }
