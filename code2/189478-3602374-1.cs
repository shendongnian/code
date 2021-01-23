Partial Public Class zzFileConverterRegistrar
    Private Sub RegisterGif(ByVal mainConverter as zzFileConverter) Handles Me.Register
        mainConverter.RegisterConverter("GIF", GifConverter.NewFactory))
    End Sub
End Class
