    'Remove the handler from the cell value changed
    Dim gv As DataGridView = Me.equipmentGridView
    Dim fInf As FieldInfo = GetType(DataGridView).GetField("EVENT_DATAGRIDVIEWCELLVALUECHANGED", BindingFlags.Static Or BindingFlags.NonPublic)
    Dim del As Object = fInf.GetValue(gv)
    Dim pInf As PropertyInfo = gv.GetType().GetProperty("Events", BindingFlags.NonPublic Or BindingFlags.Instance)
    Dim evList As EventHandlerList = pInf.GetValue(gv, Nothing)
    evList.RemoveHandler(del, evList(del))
