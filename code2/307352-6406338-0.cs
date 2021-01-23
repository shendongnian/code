      public static IEnumerable<string> FormatSubsetList<T>(this IEnumerable<T> input, int every, Func<IEnumerable<T>,string> formatter)
      {
         List<T[]> list = new List<T[]> ();
         int index = 0;
         foreach (T i in input)
         {
            T[] array;
            if (index % every == 0)
               list.Add (array = new T[every]);
            else
               array = list[list.Count - 1];
            array[index++ % every] = i;
         }
         return list.Select(t => t.Where (i => i != null)).Select(formatter);
      }
      static Program()
      {
         List<Widget> widgets = new List<Widget> ();
         Func<IEnumerable<Widget>,string> formatter = 
            items => items.Aggregate (new StringBuilder ("<div>"), (sb,w) => sb.Append(" ").Append (w.Name), sb => sb.Append ("</div>").ToString ());
         widgets.FormattedSubsetList(3, formatter);
      }
