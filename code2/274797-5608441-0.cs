    double[,] a = new double[,] {
    	{1,2,3},
    	{4,5,6}
    };
    double[,] b = new double[,] {
    	{7,8,9,10},
    	{11,12,13,14},
    	{15,16,17,18}
    };
    int m = a.GetLength(0);
    int n = b.GetLength(1);
    int k = a.GetLength(1);
    double[,] c = new double[m,n];
    alglib.rmatrixgemm(m, n, k, 1, a, 0,0,0, b,0,0,0, 0, ref c, 0,0);
    //c = {{74, 80, 86, 92}, {173, 188, 203, 218}}
