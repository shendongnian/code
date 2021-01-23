    yourGrid_RowDataBound(object sender, EventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            YourClass currentClass = (YourClass) e.Row.DataItem;
            for (int i = 0; i < currentClass.stringFlags.Length; i++)
            {
                string currentFlag = currentClass.stringFlags[i];
                if (currentFlag == "Tax")
                {
                    Image imgTax = (Image) e.Row.FindControl("imgTax");
                    imgTax.Visbile = true;
                }
                else if (currentFlag == "Compliance")
                {
                    Image imgCompliance = (Image) e.Row.FindControl("imgCompliance");
                    imgCompliance.Visbile = true;
                }
                else if (currentFlag == "Accounting")
                {
                    Image imgAccounting = (Image) e.Row.FindControl("imgAccounting");
                    imgAccounting.Visbile = true;
                }
            }
        }
    }
