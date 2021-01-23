    //Microsoft.Office.Interop.Excel.Range RoomType;
    //List<double> _RoomType;
    object[,] roomTypeArray = Array.CreateInstance(
        typeof(object),
        new int[] { 1, _RoomType.Count},
        new int[] { 1, 1 });
    for (int i = 0; i < _RoomType.Count; i++)
    {
        roomTypeArray[1, i + 1] = _RoomType[i];
    }
    RoomType.Value2 = roomTypeArray;
