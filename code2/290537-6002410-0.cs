    Public Sub Screen_Load() Handles MyBase.OnLoad
    
        Dim controls = GetType().GetFields(BindingFlags.Instance Or BindingFlags.NonPublic) _
                                .Where(Function(f) f.FieldType.IsSubclassOf(GetType(AresControl)) _
                                .Select(Function(f) f.GetValue(Me)) _
                                .Cast(Of AresControl)
    
        For Each c In controls
            MyBase.Controls.Add(c)
        Next
    End Sub
