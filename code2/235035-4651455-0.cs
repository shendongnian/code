    class PassingRefByVal 
    {
       static void Change(int[] arr)
       {
          //arr[0]=888;   // This change affects the original element.
          arr = new int[5] {-3, -1, -2, -3, -4};   // This change is local.
          Console.WriteLine("Inside the method, the first element is: {0}", arr[0]);
       }
       
       public static void Main() 
       {
          int[] myArray = {1,4,5};
          Console.WriteLine("Inside Main, before calling the method, the first element is: {0}", myArray [0]);
          Change(myArray);
          Console.WriteLine("Inside Main, after calling the method, the first element is: {0}", myArray [0]);
          Console.ReadLine();
       }
    }
