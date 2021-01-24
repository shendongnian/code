    public static void readData(ArrayList arlst)
    {
         
        foreach (object l in arlst)
        {
            // try to convert it to arrayList to keep 
            var data = l as ArrayList;safe!
            if (data != null)
               // it is an arrayList, loop on it an print values
               foreach (object item in data)
                   Console.WriteLine($"... {item.ToString()} ...");
            else
               // print the value if it is not an array list
               Console.WriteLine($"... {item.ToString()} ...");
        }
    }
