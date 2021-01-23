    public class SelectList
    {
        // Normal SelectList properties/methods go here
        public static SelectList Of<T>()
        {
           Type t = typeof(T);
           if (t.IsEnum)
           {
               var values = from Enum e in Enum.GetValues(t)
                            select new { ID = e, Name = e.ToString() };
               return new SelectList(values, "Id", "Name");
           }
           return null;
        }
    }
    // called with 
    var list = SelectList.Of<Things>();
