    class SubClasss2 : Base
    {
        public SubClasss1 MyFunction()
        {
            SubClasss1 copy = new SubClasss1(this.Data);
            
            return copy;
        }
    }
