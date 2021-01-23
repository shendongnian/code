    Brands
    {
      ID,
      Info1,
      Info2
    }
    
    Business
    {
      ID,
      BusinessName,
      BusinessDesc,
      OtherStuff1,
      OtherStuff2
    }
    
    BusinessToBrands
    {
      ID,
      BrandsID(FK to Brands),
      BusinessID(FK to Business)
    }
