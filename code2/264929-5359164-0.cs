    PropertyInfo[] props = this.GetType().GetProperties();
    foreach( PropertyInfo pi in props )
    {
      Data.ReadToFollowing( pi.Name );
      if( pi.PropertyType == typeof( bool ) )
      {
        pi.SetValue( this, bool.Parse( Data.ReadElementContentAsString() ), null );
      }
      else
      {
        pi.SetValue( this, Data.ReadElementContentAsString(), null );
      }
    }
