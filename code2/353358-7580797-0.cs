        static public int addTwoEach(int[] args)
        {
            int sum = 0;
    
            foreach (var item in args)
            {
                sum += item + 2;
            }
    
            return sum;
        }
    //Somewhere in code:
    addtwoEach (); //Throw an error
    
        static public int addTwoEach(params int[] args)
        {
            int sum = 0;
    
            foreach (var item in args)
            {
                sum += item + 2;
            }
    
            return sum;
        }
    
    //Somewhere in code:
    addtwoEach (); //Everything is OK
