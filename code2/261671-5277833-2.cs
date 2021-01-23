    public static void FillMyList(ArrayList temp)
     {
      char c='y';
    
      do {
         Console.WriteLine("Enter a value");
         int x = Int32.Parse(Console.ReadLine());  
         temp.Add(x);
         Console.WriteLine("Continue adding numbers to list, if so type y");
         char c = Console.ReadLine();
      }while(c=='y' || c=='Y');
     }
