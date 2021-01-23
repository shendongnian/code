	Imports Microsoft.VisualBasic
	Imports System.IO
	Imports System.Drawing
	Imports System.Drawing.Text
	Imports System.Drawing.Imaging
	Imports System.Drawing.Drawing2D
	Public Class clsUtility
	Public Shared Function GetFontPic(ByVal Fontpath As String, ByVal Text As String) As System.Drawing.Bitmap
	Dim width As Integer = 620
	Dim height As Integer = 30
	Dim FontImage As New System.Drawing.Bitmap(width, height, PixelFormat.Format24bppRgb)
	Dim g As Graphics = Graphics.FromImage(FontImage)
	g.Clear(Color.White)
	g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias
	g.SmoothingMode = SmoothingMode.AntiAlias
	Dim pointF As New PointF(10,0)
	Dim FontSize As Integer = 24
	Dim solidBrush As New SolidBrush(Color.Black)
	Dim privateFontCollection As New PrivateFontCollection()
	privateFontCollection.AddFontFile(Fontpath) ' load font from file
	Dim thisFont As FontFamily = privateFontCollection.Families(0)
	Dim regFont As New Font(thisFont, FontSize, FontStyle.Regular, GraphicsUnit.Pixel) ' Create a new font
	g.DrawString(Text, regFont, solidBrush, pointF) ' Using the font write the text using the font style
	Return FontImage
	End Function
