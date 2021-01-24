    using System; 
    using System.Collections.Generic; 
      
    class GFG : IComparer<string> 
    { 
        public int Compare(string x, string y) 
        { 
            if (x == null || y == null) 
            { 
                return 0; 
            } 
              
            // "CompareTo()" method 
            return x.CompareTo(y); 
              
        } 
    } 
  
    public class geek 
    { 
        public static void Main() 
        { 
            List<string> list1 = new List<string>(); 
              
            // list elements 
            list1.Add("C++"); 
            list1.Add("Java"); 
            list1.Add("C"); 
            list1.Add("Python"); 
            list1.Add("HTML"); 
            list1.Add("CSS"); 
            list1.Add("Scala"); 
            list1.Add("Ruby"); 
            list1.Add("Perl"); 
      
            int range = 4; 
           
            GFG gg = new GFG(); 
              
            Console.WriteLine("\nSort a range with comparer:"); 
              
            // sort the list within a  
            // range of index 1 to 4 
            // where range = 4 
            list1.Sort(1, range, gg); 
          
            Console.WriteLine("\nBinarySearch and Insert Dart"); 
      
            // Binary Search and storing  
            // index value to "index" 
            int index = list1.BinarySearch(0, range, 
                                        "Dart", gg); 
              
            if (index < 0) 
            { 
                list1.Insert(~index, "Dart"); 
                range++; 
            } 
      
        } 
          
       
    } 
