    protected BusinessObjectBase( SerializationInfo info, StreamingContext context )
    {
        this.DBOItem = new T();
                PropertyInfo[] properties = this.DBOItem.GetType().GetProperties();
                SerializationInfoEnumerator enumerator = info.GetEnumerator();
    
                while ( enumerator.MoveNext() )
                {
                    SerializationEntry se = enumerator.Current;
                    foreach ( PropertyInfo pi in properties )
                    {
                        if ( pi.Name == se.Name )
                        {
                            pi.SetValue( this.DBOItem, info.GetValue( se.Name, pi.PropertyType ), null );
                        }
                    }
                }
    }
