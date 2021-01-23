    namespace Garden //same as namespace of your entity object
    {
        public class CustomFlower  
        {
            public Flower originalFlowerEntityFramework;
            // An extra custom attribute
            public int standardPrice;
            public CustomFlower(Flower paramOriginalFlowerEntityFramework)
            { 
                this.originalFlowerEntityFramework = paramOriginalFlowerEntityFramework
            }
            // An extra custom method
            public int priceCustomFlowerMethod()
            {
                if (this.originalFlowerEntityFramework.name == "Rose" ) 
                    return this.originalFlowerEntityFramework.price * 3 ;
                else 
                    return this.price ;
            }
        }
    }
