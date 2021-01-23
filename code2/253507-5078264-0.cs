    class SkipComparison<T> {
      public T Source { get; set; }
      public T Other { get; set; }
      public List<PropertyInfo> PropertiesToSkip { get; set; }
      public SkipComparison<T> Skip<R>(Expression<Func<R>> f)
        // TODO: Extract property info, add it to 
        // 'PropertiesToSkip' and 'return this;'
      public bool Run()
        // TODO: Actually perform the comparison here
    }
