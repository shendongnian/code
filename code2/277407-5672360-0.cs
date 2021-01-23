    Pay p1 = new Pay();
    // Here, set the number of dependents.
    p1.NumOfDependents = dependents;
    if (checkBoxSalesperson.Checked == true)
    {
        inValue = textBoxSalesAmount.Text;
        salesAmount = double.Parse(inValue);
        grossPay = p2.CalculateGrossPay(hours, rate, salesAmount);
    } 
    else
    {
        grossPay = p1.CalculateGrossPay(hours, rate);
    }
