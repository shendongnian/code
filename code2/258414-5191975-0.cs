    Imports System
    Imports System.IO
    Class Program
    
        Public Shared Sub Main()
            Try
                ' Initialize a Stream resource to pass 
                ' to the DisposableResource class.
               Console.Write("Enter filename and its path: ")
                Dim fileSpec As String = Console.ReadLine
                Dim fs As FileStream = File.OpenRead(fileSpec)
                Dim TestObj As DisposableResource = New DisposableResource(fs)
    
                ' Use the resource.
                TestObj.DoSomethingWithResource()
    
                ' Dispose theresource.
                TestObj.Dispose()
    
            Catch e As FileNotFoundException
                Console.WriteLine(e.Message)
            End Try
        End Sub
    End Class
    
    ' This class shows how to use a disposable resource.
    ' The resource is first initialized and passed to
    ' the constructor, but it could also be
    ' initialized in the constructor.
    ' The lifetime of the resource does not 
    ' exceed the lifetime of this instance.
    ' This type does not need a finalizer because it does not
    ' directly create a native resource like a file handle
    ' or memory in the unmanaged heap.
    Public Class DisposableResource
        Implements IDisposable
    
        Private _resource As Stream
    
        Private _disposed As Boolean
    
        ' The stream passed to the constructor
        ' must be readable and not null.
        Public Sub New(ByVal stream As Stream)
            MyBase.New()
            If (stream Is Nothing) Then
                Throw New ArgumentNullException("Stream is null.")
            End If
            If Not stream.CanRead Then
                Throw New ArgumentException("Stream must be readable.")
            End If
            _resource = stream
            Dim objTypeName As String = _resource.GetType.ToString
            _disposed = False
        End Sub
    
        ' Demonstrates using the resource.
        ' It must not be already disposed.
        Public Sub DoSomethingWithResource()
            If _disposed Then
                Throw New ObjectDisposedException("Resource was disposed.")
            End If
    
            ' Show the number of bytes.
            Dim numBytes As Integer = CType(_resource.Length, Integer)
            Console.WriteLine("Number of bytes: {0}", numBytes.ToString)
        End Sub
    
        Public Overloads Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
    
            ' Use SupressFinalize in case a subclass
            ' of this type implements a finalizer.
            GC.SuppressFinalize(Me)
        End Sub
    
        Protected Overridable Overloads Sub Dispose(ByVal disposing As Boolean)
            If Not _disposed Then
    
                ' If you need thread safety, use a lock around these 
                ' operations, as well as in your methods that use the resource.
                If disposing Then
                    If (Not (_resource) Is Nothing) Then
                        _resource.Dispose()
                    End If
                    Console.WriteLine("Object disposed.")
                End If
    
                ' Indicates that the instance has been disposed.
                _resource = Nothing
                _disposed = True
            End If
        End Sub
    End Class
