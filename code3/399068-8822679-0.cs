    //Set the amount of the four series to zero
    float totalAmountHousing = 0, totalAmountPersonnel = 0, totalAmountServices = 0, totalAmountIT = 0;
   
    //Create the four series per year
    Series sr = new Series(); Series sr2 = new Series(); Series sr3 = new Series(); Series sr4 = new Series();
    //Set the series to the same chart area
    sr.ChartArea = "mainArea"; sr2.ChartArea = "mainArea"; sr3.ChartArea = "mainArea"; sr4.ChartArea = "mainArea";
  
    //Set them to the same legend
    sr.Legend = "mainLegend"; sr2.Legend = "mainLegend"; sr3.Legend = "mainLegend"; sr4.Legend = "mainLegend";
   
    //Set the names of the 4 series
    sr.Name = "Housing"; sr2.Name = "IT"; sr3.Name = "Services"; sr4.Name = "Personnel";
    
    //Add the series to the chart
    Chart1.Series.Add(sr); Chart1.Series.Add(sr2); Chart1.Series.Add(sr3); Chart1.Series.Add(sr4);
    
    //Set drawing style to cylinder of the four costs
    Chart1.Series["Housing"]["DrawingStyle"] = "Cylinder";
    Chart1.Series["IT"]["DrawingStyle"] = "Cylinder";
    Chart1.Series["Services"]["DrawingStyle"] = "Cylinder";
    Chart1.Series["Personnel"]["DrawingStyle"] = "Cylinder";
    
    for (int i = 0; i < listOfFiscalYears.Count; i++) {
    
        //generate some point for the chart
        for (int j = 0; j < listOfCosts.Count; j++) {
            if ((listOfCosts[j].Type).ToLower() == "housing"	&& listOfCosts[j].Cost_fiscalYear.Year == int.Parse(listOfFiscalYears[i].ToString())) totalAmountHousing += (float)listOfCosts[j].Amount;
            if ((listOfCosts[j].Type).ToLower() == "it"			&& listOfCosts[j].Cost_fiscalYear.Year == int.Parse(listOfFiscalYears[i].ToString())) totalAmountIT += (float)listOfCosts[j].Amount;
            if ((listOfCosts[j].Type).ToLower() == "services"	&& listOfCosts[j].Cost_fiscalYear.Year == int.Parse(listOfFiscalYears[i].ToString())) totalAmountServices += (float)listOfCosts[j].Amount;
            if ((listOfCosts[j].Type).ToLower() == "personnel"	&& listOfCosts[j].Cost_fiscalYear.Year == int.Parse(listOfFiscalYears[i].ToString())) totalAmountPersonnel += (float)listOfCosts[j].Amount;
        }
        Chart1.Series["Housing"].Points.Add(totalAmountHousing);
        Chart1.Series["IT"].Points.Add(totalAmountIT);
        Chart1.Series["Services"].Points.Add(totalAmountServices);
        Chart1.Series["Personnel"].Points.Add(totalAmountPersonnel);
        Chart1.ChartAreas["mainArea"].AxisX.Interval = 1;
        //Add custom label to the X axis
        Chart1.ChartAreas[0].AxisX.CustomLabels.Add(new CustomLabel(i, i + 2, (listOfFiscalYears[i].ToString()), 0, LabelMarkStyle.None));
        //Reset the total cost after they have been added for the year
        totalAmountHousing = 0; totalAmountPersonnel = 0; totalAmountServices = 0; totalAmountIT = 0;
    }
