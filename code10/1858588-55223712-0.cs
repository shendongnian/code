    class MyViewModel { 
        public int Ordered {get; set;}
        public int Stock {get; set;}
        public int Total => Stock - Ordered;
    }
