    public override bool CanConvertFrom( ITypeDescriptorContext context, Type sourceType ) {
      if ( sourceType == typeof( string ) )
        return true;
      return false;
    }
    
    public override bool CanConvertTo( ITypeDescriptorContext context, Type destinationType ) {
      if ( destinationType == typeof( string ) )
        return true;
      return false;
    }
