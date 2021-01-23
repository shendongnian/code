    public IEnumerable<Object> ValidObjects{ 
        get{ 
            return LFs.Where(item => item.IsObjectValid)
                      .OrderBy(item => item.SomeProperty); 
        } 
    } 
