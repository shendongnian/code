    Imports System.IO
    Imports System.Text
    Imports System
    
    
    Public Class WebForm1
        Inherits System.Web.UI.Page
    
    
    
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    
        End Sub
    
        'Protected Sub Calendar1_SelectionChanged(sender As Object, e As EventArgs)
    
        '    TextBox1.Text = Calendar1.SelectedDate.ToShortDateString()
        '    Calendar1.Visible = False
    
    
    
    
    
    
    
    
    
    
    
    
        'End Sub
    
        'Protected Sub LinkButton1_Click(sender As Object, e As EventArgs)
        '    'Calendar1.Visible = True
    
    
        'End Sub
    
        'Protected Sub LinkButton2_Click(sender As Object, e As EventArgs)
        '    Calendar2.Visible = True
        'End Sub
    
        'Protected Sub Calendar2_SelectionChanged(sender As Object, e As EventArgs)
        '    TextBox2.Text = Calendar2.SelectedDate.ToShortDateString()
        '    Calendar2.Visible = False
        'End Sub
    
        Public Sub DownloadCSV()
            Dim csvPath1 As String = "D:\CSVFile1.csv"
    
            'Download and read all Text within the uploaded Text file.
            Dim csvContentStr1 As String = File.ReadAllText(csvPath1)
    
            Dim split As String() = csvContentStr1.Split(","c)
    
            'Here you can see the output as CSV content.
            'Response.Write(csvContentStr)
        End Sub
    
    
        Public Sub UploadCSV()
            Dim csvContent As New StringBuilder()
    
            DownloadCSV()
    
            Dim dt1 As DateTime = Convert.ToDateTime(TextBox1.Text)
            Dim dt2 As DateTime = Convert.ToDateTime(TextBox2.Text)
            Dim dt3 As TimeSpan = dt2.Subtract(dt1)
            Dim NoOfDays As Integer = dt3.Days + 1
            'TextBox3.Text = NoOfDays.ToString
    
            Dim index As DateTime = Convert.ToDateTime(TextBox1.Text)
            While index <= Convert.ToDateTime(TextBox2.Text)
                If index.DayOfWeek = DayOfWeek.Saturday OrElse index.DayOfWeek = DayOfWeek.Sunday Then
                    NoOfDays = NoOfDays - 1
                End If
                index = index.AddDays(1)
    
            End While
    
            Dim a1 As String = TextBox1.ToString()
            Dim b1 As String = TextBox2.ToString()
            Dim c1 As String = RadioButtonList1.Text.ToString()
            Dim d1 As String = TextBox3.ToString()
            
            Dim z1 As String = TextBox1.Text + "," + TextBox2.Text + "," + RadioButtonList1.Text + "," + TextBox3.Text + "," + NoOfDays.ToString
    
            'csvContent.AppendLine("From Date,To Date,Laeve Type,Reason")
            csvContent.AppendLine(z1)
    
            Dim csvPath As String = "D:\CSVFile2.csv"
    
            ' Save or upload CSV format File (.csv)
            File.AppendAllText(csvPath, csvContent.ToString())
        End Sub
       
    
        Protected Sub Button1_Click(sender As Object, e As EventArgs)
    
    
    
    
    
    
    
    
            If Page.IsValid Then
                Dim a1 As String = TextBox1.ToString()
                Dim b1 As String = TextBox2.ToString()
                Dim c1 As String = RadioButtonList1.Text.ToString()
                Dim d1 As String = TextBox3.ToString()
    
    
    
    
    
                UploadCSV()
                DownloadCSV()
    
    
            End If
    
    
    
    
        End Sub
    
        Protected Sub Button2_Click(sender As Object, e As EventArgs)
    
        End Sub
    
        
    
    
    
    
    
    
    End Class
    
    
    
