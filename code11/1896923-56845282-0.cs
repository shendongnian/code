    Console.WriteLine("Enter the array Size:\t");
    int n = Convert.ToInt32(Console.ReadLine());   
    int[] arrSum = new int[n];         
    Console.WriteLine("Enter the array elements of {0} as Array Size:\n",n);
    for(int i = 0;i<n;i++){
        arrSum[i]= Convert.ToInt32(Console.ReadLine());
    }
    Console.WriteLine("Enter the number whose sum you want to find:\n");
    int j = Convert.ToInt32(Console.ReadLine());
    ArraySum(arrSum,n,j);
