    Option Explicit On
    Option Strict On
    
    Imports iTextSharp.text
    Imports iTextSharp.text.pdf
    Imports System.IO
    
    Public Class Form1
        ''//Holds our state information
        Private PageState As CustomPageState
        Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ''//Create a new document
            Dim Doc As New iTextSharp.text.Document(PageSize.LETTER)
    
            ''//Write it to a memory stream
            Using FS As New FileStream(Path.Combine(My.Computer.FileSystem.SpecialDirectories.Desktop, "Output.pdf"), FileMode.Create, FileAccess.Write, FileShare.Read)
                ''//Grab the writer
                Dim writer = PdfWriter.GetInstance(Doc, FS)
                ''//Create an object that we can pass by reference around to store the page state
                Me.PageState = New CustomPageState()
                ''//Wire our event handler and pass in the page state
                writer.PageEvent = New MyCustomPdfEvent(Me.PageState)
                ''//Open the PDF for writing
                Doc.Open()
    
                ''//Main loop, create a bunch of pages
                For I = 1 To 10
                    Doc.NewPage()
                    Doc.Add(New Phrase("Hello"))
    
                    ''//This code goes at the very end of our main loop
                    If I = 10 Then Me.PageState.IsLastPage = True
                Next
                ''//Close the PDF
                Doc.Close()
    
            End Using
        End Sub
        ''//This is our state container. Its just has a boolean value but its wrapped in a class so that we can pass it around by reference
        Public Class CustomPageState
            Public Property IsLastPage As Boolean = False
        End Class
    
        Public Class MyCustomPdfEvent
            Implements IPdfPageEvent
            ''//Reference to the state container
            Private PageState As CustomPageState
    
            Public Sub New(ByRef pageState As CustomPageState)
                Me.PageState = pageState
            End Sub
    
            Public Sub OnEndPage(ByVal writer As iTextSharp.text.pdf.PdfWriter, ByVal document As iTextSharp.text.Document) Implements iTextSharp.text.pdf.IPdfPageEvent.OnEndPage
                If Me.PageState.IsLastPage Then
                    ''//Last page, do something different
                Else
                    ''//Do normal page footer
                End If
            End Sub
    
            Public Sub OnChapter(ByVal writer As iTextSharp.text.pdf.PdfWriter, ByVal document As iTextSharp.text.Document, ByVal paragraphPosition As Single, ByVal title As iTextSharp.text.Paragraph) Implements iTextSharp.text.pdf.IPdfPageEvent.OnChapter
    
            End Sub
    
            Public Sub OnChapterEnd(ByVal writer As iTextSharp.text.pdf.PdfWriter, ByVal document As iTextSharp.text.Document, ByVal paragraphPosition As Single) Implements iTextSharp.text.pdf.IPdfPageEvent.OnChapterEnd
    
            End Sub
    
            Public Sub OnCloseDocument(ByVal writer As iTextSharp.text.pdf.PdfWriter, ByVal document As iTextSharp.text.Document) Implements iTextSharp.text.pdf.IPdfPageEvent.OnCloseDocument
    
            End Sub
    
            Public Sub OnGenericTag(ByVal writer As iTextSharp.text.pdf.PdfWriter, ByVal document As iTextSharp.text.Document, ByVal rect As iTextSharp.text.Rectangle, ByVal text As String) Implements iTextSharp.text.pdf.IPdfPageEvent.OnGenericTag
    
            End Sub
    
            Public Sub OnOpenDocument(ByVal writer As iTextSharp.text.pdf.PdfWriter, ByVal document As iTextSharp.text.Document) Implements iTextSharp.text.pdf.IPdfPageEvent.OnOpenDocument
    
            End Sub
    
            Public Sub OnParagraph(ByVal writer As iTextSharp.text.pdf.PdfWriter, ByVal document As iTextSharp.text.Document, ByVal paragraphPosition As Single) Implements iTextSharp.text.pdf.IPdfPageEvent.OnParagraph
    
            End Sub
    
            Public Sub OnParagraphEnd(ByVal writer As iTextSharp.text.pdf.PdfWriter, ByVal document As iTextSharp.text.Document, ByVal paragraphPosition As Single) Implements iTextSharp.text.pdf.IPdfPageEvent.OnParagraphEnd
    
            End Sub
    
            Public Sub OnSection(ByVal writer As iTextSharp.text.pdf.PdfWriter, ByVal document As iTextSharp.text.Document, ByVal paragraphPosition As Single, ByVal depth As Integer, ByVal title As iTextSharp.text.Paragraph) Implements iTextSharp.text.pdf.IPdfPageEvent.OnSection
    
            End Sub
    
            Public Sub OnSectionEnd(ByVal writer As iTextSharp.text.pdf.PdfWriter, ByVal document As iTextSharp.text.Document, ByVal paragraphPosition As Single) Implements iTextSharp.text.pdf.IPdfPageEvent.OnSectionEnd
    
            End Sub
    
            Public Sub OnStartPage(ByVal writer As iTextSharp.text.pdf.PdfWriter, ByVal document As iTextSharp.text.Document) Implements iTextSharp.text.pdf.IPdfPageEvent.OnStartPage
    
            End Sub
        End Class
    End Class
