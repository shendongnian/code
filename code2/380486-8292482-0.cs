    static void Main(string[] args)
    {           
    int val, isDecrement;            
    Console.WriteLine("Please enter a number!");
    val = Int32.Parse(Console.ReadLine());      
    Console.WriteLine("Please enter 1 to go Descending order!");   
    isDecrement = Int32.Parse(Console.ReadLine()); 
    if(isDecrement ==1)
    {
       for (int i = val; i >= (val - 10); i--)
         Console.WriteLine(i);            
    }
    else
    {
    for (int i = val; i <= (val + 10); i++)
      Console.WriteLine(i);            
    }
    Console.ReadLine();         
    }
