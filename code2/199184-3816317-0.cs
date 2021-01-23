    public int Compare(Resource x, Resource y) {  
      int result = x.Priority.CompareTo(y.Priority);
      if (result == 0) {
        result = x.Id.CompareTo(y.Id);  
      }
      return result;
    }
