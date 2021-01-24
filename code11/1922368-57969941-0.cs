    List<Type> toPrint = new List<Type>();  //list of enum "categories"
    ShopperList(typeof(meats));
    ShopperList(typeof(fruits));
    
    void ShopperList(Type category){
         toPrint.Add(category);
    }
    
    void PrintCategories(List<Type> toPrint){
         foreach (Type category in toPrint){
              foreach(string name in Enum.GetNames(category)){
                   Console.WriteLine(name + ", ");
              }
         }
    }
