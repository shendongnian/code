      public static void CopyOver(Parent p, Child c)
      {
          PropertyInfo[] props = p.GetType().GetProperties(BindingFlags.Public);
          foreach( PropertyInfo pi in props)
          {
             pi.SetValue( c, pi.GetValue( p) );
          }
      }
