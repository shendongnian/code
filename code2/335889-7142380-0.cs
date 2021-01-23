    Public Class Form1
        Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            For Index As Integer = 0 To 4
                Dim Control As New Label
                Control.Text = String.Format("Control {0}", Index)
                AddHandler Control.Click, AddressOf Control_Click
                TableLayoutPanel1.Controls.Add(Control, 0, 0)
            Next
        End Sub
        Private Sub Control_Click(sender As Object, e As EventArgs)
            Dim Pos1 As TableLayoutPanelCellPosition = TableLayoutPanel1.GetPositionFromControl(sender)
            Dim Pos2 As TableLayoutPanelCellPosition = TableLayoutPanel1.GetCellPosition(sender)
            Dim Text As String = String.Format("GetPositionFromControl = {0},{1}" & vbCrLf & "GetCellPosition = {2},{3}", Pos1.Column, Pos1.Row, Pos2.Column, Pos2.Row)
            MessageBox.Show(Text)
        End Sub
    End Class
