    public class H1: H
    {
        private X m_x;
        private X1 m_x1;
    
        public H1(X x):base(x)
        {
            m_x=x;
            X1 x1 = x as X1;
            if (x1!=null)
                m_x1=x1;
        }
    }
