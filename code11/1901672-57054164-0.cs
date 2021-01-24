    namespace HelloWorld 
    { 
        public class ArraysHandling  //Creating a new Class
        { 
           public int[] numb;
    
           public void arrays()
           {
             this.numb = new int[3] { 8, 9, 10 };
           }                    
         }
       }    
    
       //Main Method
       static void Main(string[] args)
       {
           ArraysHandling learningArrays = new ArraysHandling();   
           learningArrays.arrays();        
           Console.WriteLine(learningArrays.numb);
       }
    }
