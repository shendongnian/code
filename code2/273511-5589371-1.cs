    abstract class Variable
    {
        public Scalar Data
        {
            get { return data; }
            set { data = value; }
        }
    
        protected Scalar data = new Scalar(0);
    
        /* other meta information etc */
    }
