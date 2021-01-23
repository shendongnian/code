    // Group the records by parent ID (potentially null)
    var childrenByParentID = _unitDataSet.Unit.AsEnumerable().
                             GroupBy(child => child.Field<int?>("ParentUnitId")).
                             ToDictionary(group => group.Key);
    // Parents = children with no parent
    var parents = childrenByParentID[null];
    // Look for the first group which sum of surfaces is not the same as the parent's surface
    var invalidGroup = childrenByParentID.FirstOrDefault(group => 
    {
      bool invalid = false;  
      
      if (group.Key != null)
      {
        // Not the parents group
        var currentParent = parents.Single(parent => parent.Field<int>("UnitID") == group.Key);
      
        var totalSurface = group.Value.Sum(row => row.Field<int>("Surface"));
        invalid = (totalSurface != currentParent.Field<int>("Surface"));
      }
    
      return invalid;
    });
    if (invalidGroup != null)
    {
      // .. do something special
    }
