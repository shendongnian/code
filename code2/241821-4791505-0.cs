    Imports System.ServiceModel
    <ServiceContract()>
    Public Interface IClientContract
    
        <OperationContract()>
        Function GetClientList() As IList(Of POCOClients)
    
    End Interface
