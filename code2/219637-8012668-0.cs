    public class BillLine
    {
        public BillLine(Bill bill)
        {
            m_Bill = bill;
        }
        private readonly Bill m_Bill;
        public Bill Bill
        {
            get { return m_Bill; }
            //supposed to be set only in the constructor
        }
        
        //(...)
    }
