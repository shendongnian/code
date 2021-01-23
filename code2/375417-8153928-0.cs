    Public Module Builder
    
        Sub BuildSolutionDebug()
            SaveAll()
            Run("", "C:\WINDOWS\Microsoft.NET\Framework\v3.5\MSBuild.exe", """" & GetSolutionName() & """ /t:ReBuild /p:Configuration=Debug /p:Platform=""Mixed Platforms""")
        End Sub
    
        Sub Run(ByVal folder As String, ByVal file As String, ByVal arguments As String)
            Dim process As New System.Diagnostics.Process()
            process.Start(System.IO.Path.Combine(folder, file), arguments)
            Try
                process.WaitForExit()
            Catch ex As Exception
    
            End Try
    
        End Sub
    
        Sub SaveAll()
            DTE.ExecuteCommand("File.SaveAll")
        End Sub
    
        Function GetSolutionName() As String
            Return DTE.Solution.FullName
        End Function
    
    End Module
