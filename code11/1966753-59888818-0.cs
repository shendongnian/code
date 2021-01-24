    // Try for Custom Labels
    for(int i = 0; i < monthArray.Length; i++)
    {
       string sMonthName = monthArray[i];
       sMonthName = char.ToUpper(sMonthName[0]) + sMonthName.Substring(1);
       CustomLabel lblMonth = new CustomLabel();
       lblMonth.FromPosition = i;
       lblMonth.ToPosition = i + 1;
       lblMonth.Text = sMonthName;
       this.chtAccum.ChartAreas[0].AxisX.CustomLabels.Add(lblMonth);
    }
