    public MyClass()
    {
    
      [IgnoreDataMember]
      // This field will be used internally
      public DateTimeOffSet? BeginDate { get; set; }
    
    
      [DataMember(Name = "beginDate")]
      // This will be used for serialzing/deserialising to Unix TimeStamp in Milliseconds 
      public long BeginDateEpoch
      {
        get { return ((DateTimeOffset)BeginDate.GetValueOrDefault()).ToUnixTimeMilliseconds(); }
        set { BeginDate= new DateTimeOffset(DateTimeOffset.FromUnixTimeMilliseconds(BeginDateEpoch).DateTime.ToLocalTime()); }
      }
      
      [IgnoreDataMember]
      public TimeSpan? Elapsed { get; set; } 
      [DataMember(Name = "elapsed")]
      public double ElapsedEpoch
      {
        get { return Elapsed.GetValueOrDefault().TotalMilliseconds;  }
        set { InstallTime = TimeSpan.FromMilliseconds(ElapsedEpoch); }
      }
    }
