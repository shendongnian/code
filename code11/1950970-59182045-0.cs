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
    
    End Class
