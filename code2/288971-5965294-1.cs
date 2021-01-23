    public abstract class BaseClass
    {
        //(...)
        protected PDFObject storePDFHelper() { /* Do stuff here */ }
        public abstract PDFObject storePDF();
    }
    public class ChildClass : BaseClass, IPDFGenerator
    {
        public override PDFObject storePDF() { return base.storePDFHelper(); }
    }
