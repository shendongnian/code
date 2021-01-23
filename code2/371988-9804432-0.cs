    Imports System.IO
    Public Class Form1
        Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim mydoc As XElement = XElement.Load("C:\Users\Documents\myfile.XML")
        Dim y As String = mydoc.ToString
        Dim z As String = mydoc.Name.Namespace.ToString
        Dim getrid As String = " xmlns=" & Chr(34) & z & Chr(34)
        y = Replace(y, getrid, "")
        Dim tr As TextReader = New StringReader(y)
        Dim newdoc As XElement = XElement.Load(tr)
        tr.Close()
        Debug.Print(newdoc.ToString)
    End Sub
