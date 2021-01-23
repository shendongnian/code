    public class PaymentProcessingSagaData : IContainSagaData
    {
        public virtual Guid Id { get; set; }
        public virtual string Originator { get; set; }
        public virtual string OriginalMessageId { get; set; }
        public virtual int RequestBatchId { get; set; }
        public virtual DateTime? WhenRequestBatchClosed { get; set; }
        public virtual string BankRequestFileName { get; set; }
        public virtual DateTime? WhenRequestFileSent { get; set; }
        public virtual string BankResponseFileName { get; set; }
        public virtual DateTime? WhenResponseFileReceived { get; set; }
        public virtual int PaymentBatchId { get; set; }
    }
