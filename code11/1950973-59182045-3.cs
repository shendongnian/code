    Public MustInherit Class ControllerBase
        Inherits Microsoft.AspNetCore.Mvc.ControllerBase
    
        Private ReadOnly _configuration As IConfiguration
        Protected ReadOnly Property Configuration As IConfiguration
            Get
                Return _configuration
            End Get
        End Property
    
        Private ReadOnly _logger As ILogger(Of Object)
        Protected ReadOnly Property Logger As ILogger(Of Object)
            Get
                Return _logger
            End Get
        End Property
    
        Private ReadOnly _signInManager As SignInManager(Of Identity.MyProjectIdentity)
        Protected ReadOnly Property SignInManager As SignInManager(Of Identity.MyProjectIdentity)
            Get
                Return _signInManager
            End Get
        End Property
    
        Private ReadOnly _userManager As UserManager(Of Identity.MyProjectIdentity)
        Protected ReadOnly Property UserManager As UserManager(Of Identity.MyProjectIdentity)
            Get
                Return _userManager
            End Get
        End Property
    
        Public Sub New(ByVal configuration As IConfiguration,
                       ByVal logger As ILogger(Of Object),
                       ByVal signInManager As SignInManager(Of Identity.MyProjectIdentity),
                       ByVal userManager As UserManager(Of Identity.MyProjectIdentity))
    
            _configuration = configuration
            _logger = logger
            _signInManager = signInManager
            _userManager = userManager
    
        End Sub
    
    End Class
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
   
     <Authorize()>
        <HttpGet("AuthenticatorQRCode/{userName}/{sharedKey}")>
        Public Async Function AuthenticatorQRCode(ByVal userName As String, ByVal sharedKey As String) As Task(Of IActionResult)
    
            Try
    
                Dim user = Await UserManager.FindByIdAsync(Me.User.FindFirst(ClaimTypes.NameIdentifier).Value)
    
                If user.UserName <> userName Then
                    Return StatusCode(403)
                End If
    
                Dim domain As String = Configuration.GetSection("Cookies").GetValue(Of String)("Domain")
                Dim qrCodeDataString As String = $"otpauth://totp/{domain}:{userName}?secret={sharedKey}&issuer={domain}&digits=6"
    
                Dim qrImage = Imaging.QRCode.GetQRCode(qrCodeDataString)
    
                Dim ms = New System.IO.MemoryStream()
                qrImage.Save(ms, ImageFormat.Png)
                ms.Position = 0
    
                Return File(ms, "image/png", "QRCode.png")
    
            Catch ex As Exception
    
                Return StatusCode(500)
    
            End Try
    
        End Function
    
    End Class
