    MyDbContext _context;
    
    // Groups FacetTypeIds by Facet into int lists 
    Dictionary<int, List<int>> createFacetGroup(int[] facetTypeIds)
    {
        var facets = new Dictionary<int, List<int>>();
    
        var facetTypes = from ft in _context.FacetTypes where facetTypeIds.Contains(ft.FacetTypeId) select ft;
        foreach (var facetType in facetTypes)
        {
            if (facets.ContainsKey(facetType.Facet.FacetId))
                facets[facetType.Facet.FacetId].Add(facetType.FacetTypeId);
            else
                facets.Add(facetType.Facet.FacetId, new List<int> { facetType.FacetTypeId });
        }
    
        return facets;
    }
    
    public List<Product> FindProductsByGroupedFacetTypeIds(int[] facetTypeIds)
    {
        var groupedFacetTypeIds = createFacetGroup(facetTypeIds);
    
        // this seem very inefficient but ToList needs to be called 
        // otherwise the results products in the foreach loop dont end 
        // up with the correct result set
        var products = _context.Products.ToList(); 
    
        foreach (var facetTypeIdGroup in groupedFacetTypeIds)
        {
            var facetTypeIdGroupArray = facetTypeIdGroup.Value.ToArray();
            products = (from p in products where p.FacetTypes.Any(x => facetTypeIdGroupArray.Contains(x.FacetTypeId)) select p).ToList();
        }
    
        return products;
    }
