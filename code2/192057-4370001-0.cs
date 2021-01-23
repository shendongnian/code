        Public Class AsyncResult
            Implements IAsyncResult
    
    #Region "CONSTRUCTORS"
    
            Public Sub New(ByVal callback As AsyncCallback, ByVal context As HttpContext)
                _asyncCallback = callback
                _httpContext = context
                _createdTime = DateTime.Now
            End Sub
    
    #End Region
    
    #Region "PROPERTIES"
    
            Public Const TimeoutSeconds As Integer = 3
    
            Private _asyncCallback As AsyncCallback
            Private _httpContext As HttpContext
            Private _createdTime As DateTime
    
            Public ReadOnly Property TimedOut() As Boolean
                Get
                    Return ((DateTime.Now - _createdTime).TotalSeconds >= TimeoutSeconds)
                End Get
            End Property
            Public Property Response() As Response
                Get
                    Return m_Response
                End Get
                Set(ByVal value As Response)
                    m_Response = value
                End Set
            End Property
            Private m_Response As Response
    
    #Region "IAsyncResult Members"
    
            Public ReadOnly Property HttpContext() As HttpContext
                Get
                    Return _httpContext
                End Get
            End Property
            Public ReadOnly Property AsyncState() As Object Implements IAsyncResult.AsyncState
                Get
                    Return m_AsyncState
                End Get
                'Set(ByVal value As Object)
                '    m_AsyncState = value
                'End Set
            End Property
            Private m_AsyncState As Object
    
            Private ReadOnly Property IAsyncResult_AsyncWaitHandle() As System.Threading.WaitHandle Implements IAsyncResult.AsyncWaitHandle
                Get
                    Throw New NotImplementedException()
                End Get
            End Property
    
            Private ReadOnly Property IAsyncResult_CompletedSynchronously() As Boolean Implements IAsyncResult.CompletedSynchronously
                Get
                    Return False
                End Get
            End Property
    
            Public ReadOnly Property IsCompleted() As Boolean Implements IAsyncResult.IsCompleted
                Get
                    Return m_isCompleted
                End Get
                'Set(ByVal value As Boolean)
                '    If Not value Then
                '        Return
                '    End If
    
                '    Me.m_isCompleted = True
                '    _asyncCallback(Me)
                'End Set
            End Property
            Private m_isCompleted As Boolean = False
    
    #End Region
    
    #End Region
    
    #Region "METHODS"
    
            Public Function ProcessRequest() As Boolean
       
                ' Any "Execution" code goes here...
    
                Return Me.IsCompleted
            End Function
    #End Region
    
        End Class
