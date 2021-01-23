    class Program
    {
     static void Main(string[] args)
     {      
      string input = Console.ReadLine();
      string[] words = new string[10];
      words = input.Split(' ');
      for (int i = 0; i < words.Length; i++)
      {            
       Console.WriteLine(words[i]);
       Console.WriteLine("test");
      }   
      Console.ReadKey();
     }
    }
