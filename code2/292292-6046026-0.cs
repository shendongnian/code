    Public Class Form1
    
        Private Sub Form1_Load(sender As Object, e As System.EventArgs) Handles Me.Load
            Me.Button1.Text = "Create"
            Me.Button2.Text = "Remove"
    
            Me.DataGridView1.AllowUserToAddRows = False
        End Sub
    
        Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
            For i As Integer = 0 To 99
                Me.DataGridView1.Rows.Add("Hello", DateTime.Now)
            Next
        End Sub
    
        Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
            Dim i As Integer = Me.DataGridView1.Rows.Count - 1
            Do
                If Me.DataGridView1.AllowUserToAddRows = False Then
                    If i < 0 Then Exit Do
                    Me.DataGridView1.Rows.RemoveAt(i - 0)
                Else
                    If i < 1 Then Exit Do
                    Me.DataGridView1.Rows.RemoveAt(i - 1)
                End If
                i -= 1
            Loop
        End Sub
    End Class
