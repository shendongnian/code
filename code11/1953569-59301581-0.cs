     public List<Product1> GetProducts(long? cId, string productCode)
            {
                var age = false; //Added in a hurry
                var gender = "M"; //Added in a hurry
                var products =
                    _unitOfWork.StagingProductRepository.GetMany(
                        x => x.CID == cId && x.ProductCode == productCode );
                if(age)
                {
                    products = products.Where(x => x.ProductAge == age);
                }
                if (gender != string.Empty)
                {
                    products = products.Where(x => x.Gender.Trim() == gender.Trim());
                }
                return products.ToList();
    
    
           
            }
