    StringBuilder sb=new StringBuilder(); 
    for (long rowCounter = 1; rowCounter <= iRows; rowCounter++)
     {
        for (long colCounter = 1; colCounter <= iCols; colCounter++)
        {
            sb.Append(Convert.ToString(saRet[rowCounter, colCounter]));
            sb.Append(",");       
         }
    sb=sb.ToString().TrimEnd(',');
    sb.Append("\n");
    }
