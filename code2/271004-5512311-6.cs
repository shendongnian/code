    foreach( CustomField f in customFields )
    {
         if( f.InternalId == "created_date" )
         {
             createdDate = f.GetStringRepresentation();
         }
         if( f.InternalId == "business_name" )
         {
             businessName = f.GetStringRepresentation();
         }
    }
