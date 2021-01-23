		static void process( object obj )
		{
			Type type = obj.GetType();
			PropertyInfo[] properties = type.GetProperties();
			// if this obj has sub properties, apply this process to those rather than this.
			if ( properties.Length > 0 )
			{
				foreach ( PropertyInfo prop in obj.GetType().GetProperties() )
				{
					if ( !processedList.Contains( prop ) )
					{
						processedList.Add( prop );
						if ( prop.PropertyType.FindInterfaces( ( t, c ) => t == typeof( IEnumerable ), null ).Length > 0 )
						{
							MethodInfo accessor = prop.GetGetMethod();
							MethodInfo[] accessors = prop.GetAccessors();
							foreach ( object item in (IEnumerable)obj )
							{
								process( item );
							}
						}
						else if ( prop.GetIndexParameters().Length > 0 )
						{
							// get an integer count value, by incrementing a counter until the exception is thrown
							int count = 0;
							while ( true )
							{
								try
								{
									prop.GetValue( obj, new object[] { count } );
									count++;
								}
								catch ( TargetInvocationException ) { break; }
							}
							for ( int i = 0; i < count; i++ )
							{
								// process the items value
								process( prop.GetValue( obj, new object[] { i } ) );
							}
						}
						else
						{
							// is normal type so.
							process( prop.GetValue( obj, null ) );
						}
					}
				}
			}
			else
			{
				// process to be applied to each property
				Console.WriteLine( "Property Value: {0}", obj.ToString() );
			}
		}
