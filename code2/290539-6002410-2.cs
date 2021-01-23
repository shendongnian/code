    Public Sub DoLoad() 
    
            Dim controls = Me.GetType.GetFields(BindingFlags.Instance Or BindingFlags.NonPublic) _
                 .Where(Function(f) f.FieldType.IsSubclassOf(GetType(AresControl))) _
                 .Select(Function(f) f.GetValue(Me)).Cast(Of AresControl)()
            For Each c In controls
                Me.Controls.Add(c)
            Next
    End Sub
