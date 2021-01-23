    MagentoService mservice = new MagentoService();
    String mlogin = mservice.login("YOUR_USERNAME", "YOUR_API_KEY");
    
    Debug.WriteLine(mlogin);
    
    String productType = "simple";
    String attributeSetId = "4"; // This is the ID of the Catalog Product Attribute Set
    String productSku = "PRODUCT_SKU";
    
    catalogProductCreateEntity[] cpce = new catalogProductCreateEntity[1];
    // Some Code blocks here will follow....
    
    catalogProductCreate[] cpc = mservice.catalogProductCreate(mlogin, productType, attributeSetId, productSku, cpce);
