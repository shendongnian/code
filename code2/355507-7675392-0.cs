    Imports System.Text.RegularExpressions
    Public Class Form1
    
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim InputString As String
            InputString = Regex.Replace(WHAT THE USER HAS ENTERED, "fu", "**")
        End Sub
    End Class
