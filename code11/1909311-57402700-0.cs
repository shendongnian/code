      public string ServiceCategoryPointer { get; set; } 
      public string CompanyPointer { get; set; }
      string IPointerTo<ServiceCategory>.Pointer 
      { 
        get => ServiceCategoryPointer; 
        set => ServiceCategoryPointer = value;
      } 
      string IPointerTo<Company>.Pointer
       { 
        get => CompanyPointer; 
        set => CompanyPointer = value;
      } 
}
