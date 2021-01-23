    var countQuery = GetProductQuery(); // this is the queryover 
                countQuery
                    .Select(new GroupCountProjection(new[]{
                        Projections.Group(() => _productAlias.Code),
                        Projections.Group(() => _storeLocationAlias.Batch),
                     }));
    int resultCount = (int)countQuery.List<object>().SingleOrDefault();
