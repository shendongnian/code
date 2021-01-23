// unbox nullable enums as the primitive, i.e. byte etc
  var nullUnderlyingType = Nullable.GetUnderlyingType( item.Info.Type );
  var unboxType = nullUnderlyingType != null && nullUnderlyingType.IsEnum ? nullUnderlyingType : item.Info.Type;
  if( unboxType == typeof(Guid))
  {
    unboxType = typeof (string);
  }
  il.Emit( OpCodes.Unbox_Any, unboxType ); // stack is now [target][target][typed-value]
  if (  ( item.Info.Type == typeof( Guid ) && unboxType == typeof( string ) ) 
        || ( nullUnderlyingType != null && nullUnderlyingType.IsEnum ) )
  {
    il.Emit( OpCodes.Newobj, item.Info.Type.GetConstructor( new[] { nullUnderlyingType ?? unboxType} ) );
  }
  il.Emit( OpCodes.Callvirt, item.Info.Setter ); // stack is now [target]
