    // Group the records by parent ID (potentially null)
    var childrenByParentID = _unitDataSet.Unit.AsEnumerable().
                             ToLookup(child => child.Field<int?>("ParentUnitId"));
    // Parents = children with no parent
    var parentsByID = childrenByParentID[null].ToLookup(parent => parent.Field<int>("UnitID"));
    // Look for the first group which sum of surfaces is not the same as the parent's surface
    var invalidGroup = childrenByParentID.FirstOrDefault(group => 
    {
      bool invalid = false;  
      
      if (group.Key != null)
      {
        // Not the parents group
        var currentParent = parentsByID[group.Key]);
      
        var totalSurface = group.Sum(row => row.Field<int>("Surface"));
        invalid = (totalSurface != currentParent.Field<int>("Surface"));
      }
    
      return invalid;
    });
    if (invalidGroup != null)
    {
      // .. do something special
    }
