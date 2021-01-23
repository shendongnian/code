    int[] lowerBounds = new int[]{ 1, 1 };
    int[] lengths = new int[] { rowCount, columnCount };  
    var myArray = 
        (object[,])Array.CreateInstance(typeof(object), lengths, lowerBounds);
    
    var dataRange = GetRangeFromMySources();
    // this example is a bit too atomic; you probably want to disable 
    // screen updates and events a bit higher up in the call stack...
    dataRange.Application.ScreenUpdating = false;
    dataRange.Application.EnableEvents = false;
    dataRange = dataRange.get_Resize(rowCount, columnCount);
    dataRange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, myArray);
    dataRange.Application.ScreenUpdating = true;
    dataRange.Application.EnableEvents = true;
