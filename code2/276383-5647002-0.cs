     If Not File.Exists(Application.StartupPath) Then
                SW = File.CreateText(Application.StartupPath + "\" + FinalPath)
                Using fs
                End Using
                Thread.Sleep(1000)
            End If
            Using SW
                SW.Write(Content.ToString)
            End Using
