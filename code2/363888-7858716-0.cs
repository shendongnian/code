    var lqClassResult = from classItem in this.dataSet._class.AsEnumerable()
        join namespaceItem in this.dataSet._namespace.AsEnumerable()
        on classItem.Field<int>("namespace_id") equals namespaceItem.Field<int>("id")
        where classItem.Field<string>("class_name").ToLowerInvariant().Contains(className.ToLowerInvariant()) &&
              namespaceItem.Field<string("namespace_name") ! =  null &&
              namespaceItem.Field<string("namespace_name").ToLowerInvariant().Contains(namespaceName.ToLowerInvariant())                                   
        orderby namespaceItem.Field<string>("namespace_name"),classItem.Field<string>("class_name")
        select new { 
             class_name = classItem.Field<string>("class_name"), 
             namespace_name = namespaceItem.Field<string>("namespace_name") 
        };
