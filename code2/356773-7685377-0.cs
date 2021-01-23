        public void GetObjectData( SerializationInfo info, StreamingContext context )
        {
            PropertyInfo[] infos = this.DBOItem.GetType().GetProperties();
            foreach ( PropertyInfo pi in infos )
            {
                bool isAssociation = false;
                foreach ( object obj in pi.GetCustomAttributes( true ) )
                {
                    if ( obj.GetType() == typeof( System.Data.Linq.Mapping.AssociationAttribute ) )
                    { isAssociation = true; break; }
                }
                if ( !isAssociation )
                {
                    if ( pi.GetValue( this.DBOItem, null ) != null )
                    {
                        info.AddValue( pi.Name, pi.GetValue( this.DBOItem, null ) );
                    }
                }
            }
        } 
