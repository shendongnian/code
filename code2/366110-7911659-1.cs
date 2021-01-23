    class Repository
    {
        void MethodA()
        {
            using (Sqlconnection)
            {
                 // db call
            }
        }
        void MethodB()
        {
            using (Sqlconnection)
            {
                // you can even have multiple calls here (roundtrips)
                // and start transactions.  
            }
        }
