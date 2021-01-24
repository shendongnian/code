    <Controller()>
    <Route("Media")>
    Public Class MediaController
    	Inherits MyProject.Controllers.ControllerBase
    
    	Private ReadOnly _mediaService As MediaService
    	Protected ReadOnly Property MediaService As MediaService
    		Get
    			Return _mediaService
    		End Get
    	End Property
    
    	Public Sub New(ByVal configuration As IConfiguration,
    				   ByVal signInManager As SignInManager(Of Identity.MyProjectIdentity),
    				   ByVal userManager As UserManager(Of Identity.MyProjectIdentity),
    				   ByVal logger As ILogger(Of MediaController),
    				   ByVal mediaService As MediaService)
    		MyBase.New(configuration, logger, signInManager, userManager)
    
    		_mediaService = mediaService
    
    	End Sub            
    
    
    	<HttpGet("Placeholder/{width:int}/{height:int}")>
    	Public Function Placeholder(ByVal width As Integer, ByVal height As Integer) As IActionResult
    
    		Try
    
    			Dim resultImage = Imaging.Placeholder.GetPlaceholderImage(300, 300)
    
    			Dim ms = New IO.MemoryStream()
    			resultImage.Save(ms, ImageFormat.Png)
    			ms.Position = 0
    
    			Return File(ms, "image/png", $"Placeholder_{width}x{height}.png")
    
    		Catch ex As Exception
    
    			Return StatusCode(500)
    
    		End Try
    
    	End Function
    
    End Class
