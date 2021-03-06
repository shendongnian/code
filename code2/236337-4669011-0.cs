                        //Copy the properties
                    foreach ( PropertyInfo oPropertyInfo in oCostDept.GetType().GetProperties() )
                    {
                        //Check the method is not static
                        if ( !oPropertyInfo.GetGetMethod().IsStatic )
                        {
                            //Check this property can write
                            if ( this.GetType().GetProperty( oPropertyInfo.Name ).CanWrite )
                            {
                                //Check the supplied property can read
                                if ( oPropertyInfo.CanRead )
                                {
                                    //Update the properties on this object
                                    this.GetType().GetProperty( oPropertyInfo.Name ).SetValue( this, oPropertyInfo.GetValue( oCostDept, null ), null );
                                }
                            }
                        }
                    }
