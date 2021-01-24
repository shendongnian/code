    Dim Num1 As NumericUpDown
    Dim Num2 As NumericUpDown
    Dim NumScore As NumericUpDown
    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        If NumScore.Value = 0 Then
            Num1.ReadOnly = True
            Num1.Increment = 0
            Num2.ReadOnly = True
            Num2.Increment = 0
        End If
    End Sub
