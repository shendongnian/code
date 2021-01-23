    using System;
    class Sample {
        public static void Main() {
        String[] val = {"apple", "orange", "grape", "pear"};
        String sep   = ", ";
        String result;
    
        Console.WriteLine("sep = '{0}'", sep);
        Console.WriteLine("val[] = {{'{0}' '{1}' '{2}' '{3}'}}", val[0], val[1], val[2], val[3]);
        result = String.Join(sep, val, 1, 2);
        Console.WriteLine("String.Join(sep, val, 1, 2) = '{0}'", result);
        }
    }
