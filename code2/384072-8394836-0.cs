    public IEnumerable<ExternalFileReference> GetLinkedFileReferences()
            {
                //ElementFilter categoryFilter = new ElementCategoryFilter(BuiltInCategory.OST_RvtLinks);
                //ElementFilter typeFilter = new ElementClassFilter(typeof(Instance));
                //ElementFilter logicalFilter = new LogicalAndFilter(categoryFilter, typeFilter);
    
                var collector = new FilteredElementCollector(_document);
                var linkedElements = collector
                    .OfClass(typeof (RevitLinkType))
                    //.OfCategory(BuiltInCategory.OST_RvtLinks)
                    //.WherePasses(logicalFilter)
                    .Select(x => x.GetExternalFileReference())
                    .ToList();
    
                return linkedElements;                       
            }
