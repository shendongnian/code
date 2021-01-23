    if(range.Count > 1)
    {
        //code...
    }
    else
    {
        string singleStrValue = range.get_Value(XL.XlRangeValueDataType.xlRangeValueDefault);
        int iRow, iCol;
        iRow = range.Row;
        iCol = range.Column;
        if (!string.IsNullOrEmpty(singleStrValue))
        {
            //code...
        }
    }
