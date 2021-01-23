    Option Explicit On
    Option Strict On
    
    Imports iTextSharp.text
    Imports iTextSharp.text.pdf
    Imports System.IO
    
    Public Class Form1
    
        Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim PDF_Input_File As String = Path.Combine(My.Computer.FileSystem.SpecialDirectories.Desktop, "Input.pdf")
            Dim PDF_Output_File As String = Path.Combine(My.Computer.FileSystem.SpecialDirectories.Desktop, "Export.pdf")
    
            ''//Create our reader
            Dim reader As New PdfReader(PDF_Input_File)
            ''//Create our file stream to output to
            Using FS As New System.IO.FileStream(PDF_Output_File, FileMode.Create, FileAccess.Write, FileShare.Read)
                ''//Create the stamper
                Dim stamper As New PdfStamper(reader, FS)
    
                ''//Just loading the XML raw instead of reading from disk, less files to attach to the post
                Dim Bytes = System.Text.Encoding.UTF8.GetBytes("<?xml version=""1.0"" encoding=""UTF-8""?><topmostSubform><Text1>Chris</Text1><DateTimeField1>2012-04-12</DateTimeField1></topmostSubform>")
                Using MS As New MemoryStream(Bytes)
                    ''//Fill out the form
                    stamper.AcroFields.Xfa.FillXfaForm(MS)
                End Using
    
                stamper.Close()
            End Using
    
            reader.Close()
    
    
            Me.Close()
        End Sub
    End Class
