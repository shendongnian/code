     static IConvertible Add (IConvertible a, IConvertible b)
     {
         if (a is string) return a.ToString() + b;
         if (b is string) return a + b.ToString();
         // other special cases here
         return a.ToDouble(CultureInfo.CurrentCulture) + b.ToDouble(CultureInfo.CurrentCulture);
     }
     static void Main(string[] args)
     {
         IConvertible a = 1;
         IConvertible b = 2;
         IConvertible s = "string";
         Console.WriteLine(Add(a, b));
         Console.WriteLine(Add(s, s));
         Console.WriteLine(Add(a, s));
     }
