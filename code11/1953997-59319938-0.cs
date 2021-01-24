        string a = "sdasd";
        object b = (object)a;
        object c = (object)a;
        if (b is string mystring) {
           Console.WriteLine(mystring);
        }
        if (c is string mystring1) {
           Console.WriteLine(mystring1);
        }
