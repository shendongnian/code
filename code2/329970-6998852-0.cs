    public static SelectList ToSelectList<TEnum>( this TEnum enumObj )
      {
         var result = ( from TEnum e in Enum.GetValues( typeof( TEnum ) )
                        select new
                        {
                           ID = (int) Enum.Parse( typeof( TEnum ), e.ToString() ),
                           Name = e.ToString()
                        } ).ToList();
         result.Insert( 0, new
                           {
                             ID = 0,
                             Name = "-- Select --"
                            } );
         return new SelectList( result, "Id", "Name", enumObj );
      }
