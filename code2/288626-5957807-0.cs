            Private Sub MySettings_SettingsLoaded(sender As Object, e As System.Configuration.SettingsLoadedEventArgs) Handles Me.SettingsLoaded
            If Not Debugger.IsAttached Then
                My.Settings.SQLCEConnectionString = "somefolder\somefile.sdf"
            End If
        End Sub
