    public class BaseClass
    {
        //(...)
        protected PDFObject storePDFHelper() { /* Do stuff here */ }
    }
    public interface IPDFGenerator
    {
        PDFObject storePDF();
    }
    public class ChildClass : BaseClass, IPDFGenerator
    {
        public PDFObject storePDF() { return base.storePDFHelper(); }
    }
