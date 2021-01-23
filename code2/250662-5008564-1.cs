    public interface ITransferAck{
        [OperationContract(IsOneWay = true)]
        void TransferRecordResendRequest(int transferId); 
    }
    [ServiceContract(CallbackContract=typeof(ITransferAck))]
    public interface IBankTransfer{
        [OperationContract(IsOneWay=true)]
        void ExchangeTransferRecord(int transferId, string record);
    }
