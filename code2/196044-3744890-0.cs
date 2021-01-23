     struct Pair
     {
         public int Number;  // the number in queryArray
         public int[] Indexes;  // the positions of the number
     }
     static List<int[]> results = new List<int[]>(); //store all possible paths
     static Queue<int> currResult = new Queue<int>(); // the container of current path
     static int[] inputArray, queryArray; 
     static Pair[] pairs;
