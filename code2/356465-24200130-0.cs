    if (!string.IsNullOrEmpty(lname) || ! string.IsNullOrEmpty(fname))
    
    {
      
    _CustomerList= _CustomerList.Where(x =>x.LastName.Contains(lname.ToUpper().Trim()) ||               
     x.FirstName.Contains(fname.ToUpper().Trim())
    );
    
    return _CustomerList.ToList();
    
    }
