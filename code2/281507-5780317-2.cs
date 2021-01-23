     public Guid TempID { get; set; }
     public Nullable<int> ID { get; set; }
     public bool Published { get; set; }
     public int CategoryLevel { get; set; }
     public int CategoryOrder { get; set; }
     public DateTime UpdatedDate { get; set; }
     public Nullable<int> RefParent { get; set; }
     public bool GotChildren { get; set; }
     public List<Categories> SubCategories {get; set;} // add this
