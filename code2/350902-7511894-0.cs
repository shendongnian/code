    public IEnumerable<string> Ages
    {
       get
       {
          return this._innerList.Select(someObj => someObj.Age).ToArray();
       }
    }
