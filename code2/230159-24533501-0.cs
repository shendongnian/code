    string sDate = (xlRange.Cells[4, 3] as Excel.Range).Value2.ToString();
     
    double date = double.Parse(sDate);
     
    var dateTime = DateTime.FromOADate(date).ToString("MMMM dd, yyyy");
      
 
