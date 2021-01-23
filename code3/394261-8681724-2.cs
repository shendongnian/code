    Imports System.Drawing
    Imports System.Drawing.Drawing2D
    Imports System.Drawing.Imaging
    Imports System.Web
    
    Namespace WebApplication2
    	''' <summary>
    	''' Summary description for ImageDisplay
    	''' </summary>
    	Public Class ImageDisplay
    		Implements IHttpHandler
    
    		Public Sub ProcessRequest(context As HttpContext) Implements IHttpHandler.ProcessRequest
    
    			context.Response.ContentType = "image/jpeg"
    
    			Dim bmp As New Bitmap(HttpContext.Current.Server.MapPath("~/Images/DSC_0165.jpg"))
    
    			Dim i As Image = FixedSize(bmp, 300, 300)
    			i.Save(HttpContext.Current.Server.MapPath("~/Images/DSC_0165-r.jpg"), ImageFormat.Jpeg)
    			i.Dispose()
    
    			context.Response.WriteFile("~/Images/DSC_0165-r.jpg")
    		End Sub
    
    		Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
    			Get
    				Return False
    			End Get
    		End Property
    
    		Private Shared Function FixedSize(imgPhoto As Image, Width As Integer, Height As Integer) As Image
    			Dim sourceWidth As Integer = imgPhoto.Width
    			Dim sourceHeight As Integer = imgPhoto.Height
    			Dim sourceX As Integer = 0
    			Dim sourceY As Integer = 0
    			Dim destX As Integer = 0
    			Dim destY As Integer = 0
    
    			Dim nPercent As Single = 0
    			Dim nPercentW As Single = 0
    			Dim nPercentH As Single = 0
    
    			nPercentW = (CSng(Width) / CSng(sourceWidth))
    			nPercentH = (CSng(Height) / CSng(sourceHeight))
    			If nPercentH < nPercentW Then
    				nPercent = nPercentH
    				destX = System.Convert.ToInt16((Width - (sourceWidth * nPercent)) / 2)
    			Else
    				nPercent = nPercentW
    				destY = System.Convert.ToInt16((Height - (sourceHeight * nPercent)) / 2)
    			End If
    
    			Dim destWidth As Integer = CInt(Math.Truncate(sourceWidth * nPercent))
    			Dim destHeight As Integer = CInt(Math.Truncate(sourceHeight * nPercent))
    
    			Dim bmPhoto As New Bitmap(Width, Height, PixelFormat.Format24bppRgb)
    			bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution)
    
    			Dim grPhoto As Graphics = Graphics.FromImage(bmPhoto)
    			grPhoto.Clear(Color.White)
    			grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic
    
    			grPhoto.DrawImage(imgPhoto, New Rectangle(destX, destY, destWidth, destHeight), New Rectangle(sourceX, sourceY, sourceWidth, sourceHeight), GraphicsUnit.Pixel)
    
    			grPhoto.Dispose()
    			Return bmPhoto
    		End Function
    
    	End Class
    End Namespace
