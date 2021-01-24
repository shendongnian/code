       static void Main(string[] args)
       {
           int size = 10000;
           List<int> items = new List<int>();
           // using: Do not forget to close the file (via IDisposable) 
           using (StreamReader SR = new StreamReader("Data.Txt")) 
           {
               while (!SR.EndOfStream) 
               {
                  items.Add(int.Parse(SR.ReadLine()));
               } 
           } 
           // Now either int[] Array = items.ToArray(); or
           int[] Array = new int[items.Count];
           for (int i = 0; i < Array.Length; ++i)
              Array[i] = items[i];
           Console.WriteLine("ARRAY BEFORE SORTING");
           ...
           
  
