    class ProductFactoryBase {
      protected void Populate(ProductBase p) {
        p.x = some_x;
        p.y = some_y;
      }
    }
    
    class ProductAFactory : ProductFactoryBase {
      public ProductBase Create() {
        ProductA p = new ProductA();
        populate(p);
        p.z = some_z;
        return p;
      }
    }
    
    class ProductBFactory : ProductFactoryBase {
      public ProductBase Create() {
        ProductB p = new ProductB();
        populate(p);
        p.a = some_a;
        return p;
      }
    }
    
    class ProductFactory {
      private ProductAFactory paf = new ProductAFactory();
      private ProductBFactory pbf = new ProductBFactory();
      ProductBase Create(bool create_A) {
        if ( create_A )
          return paf.Create();
        else
          return pbf.Create();
      }
    }
