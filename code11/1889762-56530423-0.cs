    public abstract class DocumentLine { ... }
    public class BillLine : DocumentLine { ... }
    public class ReceiptLine : DocumentLine { ... }
    public abstract class Document<TDocLine> where TDocLine : DocumentLine
    {
        public List<TDocLine> Lines { get; set; }
    }
    public class Bill : Document<BillLine> { ... }
    public class Receipt : Document<ReceiptLine> { ... }
