    'Rename this Module **cData**
    Option Explicit
    Private pCorrelationID As String
    Private pRequestForApi As String
    Private pCaller As String
    Private pRequestedSchemas As String
    Private pTenantID As String
    
    Public Property Get CorrelationID() As String
        CorrelationID = pCorrelationID
    End Property
    Public Property Let CorrelationID(Value As String)
        pCorrelationID = Value
    End Property
    
    Public Property Get RequestForApi() As String
        RequestForApi = pRequestForApi
    End Property
    Public Property Let RequestForApi(Value As String)
        pRequestForApi = Value
    End Property
    
    Public Property Get Caller() As String
        Caller = pCaller
    End Property
    Public Property Let Caller(Value As String)
        pCaller = Value
    End Property
    
    Public Property Get RequestedSchemas() As String
        RequestedSchemas = pRequestedSchemas
    End Property
    Public Property Let RequestedSchemas(Value As String)
        pRequestedSchemas = Value
    End Property
    
    Public Property Get TenantID() As String
        TenantID = pTenantID
    End Property
    Public Property Let TenantID(Value As String)
        pTenantID = Value
    End Property
