        Dim oOpt As LibGit2Sharp.CloneOptions = Nothing
        Dim oCred As LibGit2Sharp.UsernamePasswordCredentials = Nothing
        Try
            oOpt = New LibGit2Sharp.CloneOptions
            oCred = New LibGit2Sharp.UsernamePasswordCredentials
            oCred.Username = "xxxxxxx"
            oCred.Password = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"
            oOpt.CredentialsProvider = New LibGit2Sharp.Handlers.CredentialsHandler(Function(_url, _user, _cred) oCred)
            Try
                LibGit2Sharp.Repository.Clone("<your repository>", "<your local folder>", oOpt)
            Catch ex As Exception
            End Try
        Catch
        Finally
            If Not oCred Is Nothing Then
                oCred = Nothing
            End If
            If Not oOpt Is Nothing Then
                oOpt = Nothing
            End If
        End Try
