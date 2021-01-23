    class TheThing {
        public int T1;
        public float T2;
    }
    List<TheThing> list = new List<TheThing>();
    
    // Populate list...
    var instance = (from thing in list
                   where thing.T1 == 4
                   select thing).SingleOrDefault();
