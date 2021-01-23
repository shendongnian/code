    Imports System.Net
    Imports System.Runtime.InteropServices
    Imports mshtml
    --Add reference Microsoft Html Object Library
    
    Sub Dowork()
    Dim x = WebBrowser1.Document.GetElementsByTagName("img")
    For i As Integer = 0 To x.Count - 1
    If x(i).GetAttribute("alt") = "Captcha image" Then
    GetImage(x(i)).Save("captcha.png", Imaging.ImageFormat.Png)
    End If
    Next
    End Sub
    <ComImport>
    <InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>
    <Guid("3050F669-98B5-11CF-BB82-00AA00BDCE0B")>
    Public Interface IHTMLElementRenderFixed
    Sub DrawToDC(hdc As IntPtr)
    Sub SetDocumentPrinter(bstrPrinterName As String, hdc As IntPtr)
    End Interface
    
    Public Function GetImage(e As HtmlElement) As Bitmap
        Dim img As IHTMLImgElement = TryCast(e.DomElement, IHTMLImgElement)
        Dim render As IHTMLElementRenderFixed = TryCast(img, IHTMLElementRenderFixed)
        Dim bmp As Bitmap = New Bitmap(e.OffsetRectangle.Width, e.OffsetRectangle.Height)
        Dim g As Graphics = Graphics.FromImage(bmp)
        Dim hdc As IntPtr = g.GetHdc()
        render.DrawToDC(hdc)
        g.ReleaseHdc(hdc)
        Return bmp
    End Function
