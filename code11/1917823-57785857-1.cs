    public class Cars
        {
            public object value { get; set; }
            public bool worked { get; set; }
        }
        public Cars GetCar(object value)
        {
            Cars c = new Cars();
            c.value = value;
            return c;
        }
        public void Main(string[] args)
        {
            string mycar = "ABC-12";
            int mycar2 = 123;
    
            if ((string)GetCar(mycar).value == "ABC")
                GetCar(mycar).worked = false;
    
            if ((int)GetCar(mycar2).value == 1) // changed mycar to mycar2 and added a cast to int
                GetCar(mycar2).worked = false;
        }
