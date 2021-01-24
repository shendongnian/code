     double[,] array = new double[,] {
       {1, 2},
       {3, 4},
     };
     double sum = array.Cast<double>().Sum();
     double max = array.Cast<double>().Max(); 
