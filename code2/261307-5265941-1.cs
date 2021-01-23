    [ServiceContract]
    interface ISomeContract
    {
       [OperationContract(IsOneWay = true)]
       void ReceiveEmpInfo(string EmpName, string EmpId)
    }
