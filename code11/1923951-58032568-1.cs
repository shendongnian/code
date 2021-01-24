        public ProductDetails getSelectedProductDetails(string productCodeID)
        {
            try
            {
                NaturesKingdomUKEntities db = new NaturesKingdomUKEntities();
                List<ProductInfo> lst_ProductInfo = db.ProductInfoes.Where(x => x.Product_Code_ID.Equals(productCodeID)).ToList();
                ProductDetails prd = new ProductDetails();                    
                prd = lst_ProductInfo
                                     .Where(y => y.Product_Code_ID.Equals(productCodeID))
                                     .Select(x => new ProductDetails { ProductName = x.Product_Name, ProductCodeID = x.Product_Code_ID, UnitPrice=Convert.ToDouble(x.Unit_Price), ProductDescription=x.Product_Description, ProductAdditionalDescription=x.Product_Additional_Description, ProductType=x.Product_Type })
                                     .FirstOrDefault();                
                return prd;                
            }
            catch (Exception ex)
            {
                throw;
            }
        }
