    using System; 
    using System.Collections.Generic; 
    
    public class Test
    { 
        public static void Main() 
        { 
                int[] myArr = {-1, 4, 8, 6}; 
                
                PrintIndexAndValues(myArr); 
                Console.WriteLine(); 
                Console.WriteLine("Taking index out of bound:"); 
                Array.Clear(myArr, 0, myArr.Length);
                
                Console.WriteLine("Array After Operation:"); 
                PrintIndexAndValues(myArr); 
        } 
        
        public static void PrintIndexAndValues(int[] myArr) 
        { 
            for (int i = 0; i < myArr.Length; i++)  
                Console.WriteLine("{0}", myArr[i]); 
        } 
    } 
