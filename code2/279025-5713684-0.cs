        public static List<B> Cast<A,B>(List<A> aLIst) where A : B
        {
            List<B> ret = new List<B>( );
            foreach (A a in aLIst)
            {
                ret.Add(a);
            }
            return ret;
        }    
