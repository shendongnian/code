    Public Class MyController
        Inherits Controller
        ...
        Private ReadOnly mApplicationSettings As IApplicationSettings
        Public Sub New(..., applicationSettings As IApplicationSettings)
            ...
            Me.mApplicationSettings = applicationSettings
        End Sub
     
        Public Function SomeAction(custId As Guid) As ActionResult
             ...
             ' Look up setting for custId
             ' If not found fall back on default like
             viewModel.SomeProperty = Me.mApplicationSettings.DefaultValue
             Return View("...", viewModel)
        End Function
    End Class
