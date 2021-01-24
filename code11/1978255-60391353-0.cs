    var elems = propValue as IList;
    if ( elems != null )
    {
         Console.WriteLine("{0}{1}:", indentString, property.Name);
         foreach ( var item in elems )
         {
				Console.WriteLine("{0}{1}",new string (' ', indent+2),item);
         }
    }
