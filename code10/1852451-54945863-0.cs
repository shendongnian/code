      public MyEnum GetStringFromEnum(string id)
            {
        
                var product = MyListOfProducts.FirstOrDefault(x => x.Id.Equals(id));
                MyEnum myEnum = (MyEnum)Convert.ToInt32(product?.CustomId);
                return myEnum;
        
            }
