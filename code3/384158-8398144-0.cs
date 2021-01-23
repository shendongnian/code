    using System;
    
    class Sample {
        static void Main(){
            int chunckSize = 4;
    
            int[] a = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            int[] b = new int[a.Length];
            int sum = 0;
            int d = chunckSize*(chunckSize-1)/2;
            foreach(var i in a){
                if(i < chunckSize){
                    sum += i;
                    b[i-1]=sum;
                } else {
                    b[i-1]=chunckSize*i -d;
                }
            }
            Console.WriteLine(String.Join(",", b));//1,3,6,10,14,18,22,26,30,34,38,42
        }
    }
