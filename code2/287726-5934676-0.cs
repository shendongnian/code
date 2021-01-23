    public static IEnumerable<myClass> GetChanged(IEnumerable<myClass> data)
    {
        bool found = false;
        foreach(myClass c in data)
        {
           if(found == false && c.c=="kitten")
           {
               found = true;
               yield return new myClass() ; //new object
           }
           else
               yield return c;
        }
    }
