      static void Main(string[] args)
        {
            //Declare a int 3-dimentions array and initial its values
            int[, ,] a = new int[,,] { { { 1, 2, 3 } }, { { 2, 3, 4 } }, { { 2, 3, 4 } } };
            if (a[0, 0, 0] == 0f) //<-- It's aright
            {
                //dosomething 
            }
            ;
    
            a[0, 0, 0] = 20; //<it's aright too
    
            //declare a 3-dimentions array 
            Array[, ,] arry = new Array[1, 2, 3]; //set its value
            arry[0, 0, 0] = new int[] { 1, 2, 3 }; 
            arry[0, 0, 1] = new int[] { 1, 2, 3 };
        }
