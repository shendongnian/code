    public override object ConvertFrom( ITypeDescriptorContext context, CultureInfo culture, object value ) {
      if ( value == null )
        return null;
      try {
        if ( value is string ) {
          string s = (string)value;
          // here is where you look at the string to figure out the MimeFormat
          // like so....
          return new MimeFormat( s );
        }
      throw new NotSupportedException( NotSupportedException( value.GetType(), typeof(MimeFormat) );
    }
    public override object ConvertTo( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType ) {
      if ( value == null )
        return null;
      MimeFormat p = (MimeFormat)value;
      if ( destinationType == typeof( String ) )
        return p.ToString();
      throw new NotSupportedException( NotSupportedException( typeof(MimeFormat), destinationType ) );
    }
