     foreach( var mapping in cfg.ClassMappings )
     {
        if( typeof (IUserContextAware).IsAssignableFrom (mapping.MappedClass) )
        {
           // The filter should define the names of the columns that are used in the DB, rather then propertynames.
          // Therefore, we need to have a look at the mapping information.
    
          Property userProperty = mapping.GetProperty ("UserId");
    
          foreach( Column c in userProperty.ColumnIterator )
          {
              string filterExpression = ":{0} = {1}";
    
              // When the BelongsToUser field is not mandatory, NULL should be taken into consideration as well.
              // (For instance: a PrestationGroup instance that is not User-bound (that can be used by any user), will have
              //  a NULL value in its BelongsToUser field).
              if( c.IsNullable )
              {
                  filterExpression = filterExpression + " or {1} is null";
              }
    
              mapping.AddFilter (CurrentUserContextFilter, "(" + filterExpression.FormatString (CurrentUserContextFilterParameter, c.Name) + ")");
              break;
         }
     }
