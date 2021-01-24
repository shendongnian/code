    public abstract class Base
    {
        protected List<Invoice> Invoices;
        public Base(List<Invoice> invoices)
        {
            Invoices = invoices;
        }
    }
    public class A : Base
    {
        public List<Invoice> DoAStuff()
        {
            //extract invoices from xlsx file
            return invoices;
        }
        public A(List<Invoice> invoices) : base(invoices)
        {
        }
    }
    public class B : Base
    {
        public List<Invoice> DoBStuff()
        {
            //Do some operations and update list
            return invoices;
        }
        public B(List<Invoice> invoices) : base(invoices)
        {
        }
    }
    public class C : Base
    {
        public List<Invoice> DoCStuff()
        {
            //Do some operations and update list
            return invoices;
        }
        public C(List<Invoice> invoices) : base(invoices)
        {
        }
    }
    public class D : Base
    {
        public void DoDStuff()
        {
            //Do Something
        }
        public D(List<Invoice> invoices) : base(invoices)
        {
        }
    }
