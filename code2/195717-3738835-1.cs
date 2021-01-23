    Module modMain
    
        Public shutdown As New Threading.ManualResetEvent(False)
    
        Public Sub FileCreated(ByVal sender As Object, ByVal e As IO.FileSystemEventArgs)
            Console.WriteLine("Created: " & e.FullPath)
        End Sub
    
        Public Sub FileChanged(ByVal sender As Object, ByVal e As IO.FileSystemEventArgs)
            Console.WriteLine("Changed: " & e.FullPath)
        End Sub
    
        Public Sub FileDeleted(ByVal sender As Object, ByVal e As IO.FileSystemEventArgs)
            Console.WriteLine("Deleted: " & e.FullPath)
        End Sub
    
        Public Sub FileRenamed(ByVal sender As Object, ByVal e As IO.FileSystemEventArgs)
            Console.WriteLine("Renamed: " & e.FullPath)
        End Sub
    
        Public Sub CancelKeyHandler(ByVal sender As Object, ByVal e As ConsoleCancelEventArgs)
            e.Cancel = True
            shutdown.Set()
        End Sub
    
        Sub Main()
    
            Dim fsw As New System.IO.FileSystemWatcher
    
            Try
    
                AddHandler Console.CancelKeyPress, AddressOf CancelKeyHandler
    
                ' Do your work here 
                ' press Ctrl+C to exit 
                fsw = New System.IO.FileSystemWatcher("c:\path")
                fsw.Filter = "*.*"
                fsw.NotifyFilter = (IO.NotifyFilters.Attributes Or IO.NotifyFilters.CreationTime Or IO.NotifyFilters.DirectoryName Or _
                                    IO.NotifyFilters.FileName Or IO.NotifyFilters.LastAccess Or IO.NotifyFilters.LastWrite Or _
                                    IO.NotifyFilters.Security Or IO.NotifyFilters.Size)
                AddHandler fsw.Created, AddressOf FileCreated
                AddHandler fsw.Changed, AddressOf FileChanged
                AddHandler fsw.Deleted, AddressOf FileDeleted
                AddHandler fsw.Renamed, AddressOf FileRenamed
                fsw.EnableRaisingEvents = True
    
                shutdown.WaitOne()
    
            Catch ex As Exception
                Console.WriteLine(ex.ToString())
            Finally
                If fsw IsNot Nothing Then fsw.Dispose()
            End Try
    
        End Sub
    
    End Module
