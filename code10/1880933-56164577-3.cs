    // IEnumerable<int> - let's generalize: what if we want to pass an array?
    public C2(IEnumerable<int> lNumbers) {
      // public method arguments validation
      if (null == lNumbers)  
        throw new ArgumentNullException(nameof(lNumbers));
      try {
        Series = lNumbers
          .OrderBy(item => item) 
          //.Take(10) // uncomment, if you want to take just top 10 items, not more
          .Select(item => new C1(item))
          .ToList();
      }
      catch (OverflowException) {
        MessageBox.Show("M1!","M2");
        throw;
      } 
    }  
