    public class ProductsDto
    {
        public int ProductId { get; set; }
        public string Productname { get; set; }
        public virtual ProductTypeDto ProductTypes { get; set; }
        public void SetDto(Products obj)
        {
            if (obj == null)
                return;
            this.ProductId = obj.ProductId;
            this.Productname = obj.Productname;
            if (obj.ProductTypes != null)
            {
                this.ProductTypes = new ProductTypeDto();
                this.ProductTypes.SetDto(obj.City);
            }
        }
    }
       
    public class ProductTypeDto
    {
        public int ProductTypeId { get; set; }
        public int ProductTypeName { get; set; }
        public void SetDto(ProductType obj)
        {
            if (obj == null)
                return;
            this.ProductTypeId = obj.ProductTypeId;
            this.ProductTypeName = obj.ProductTypeName;
        }
    }
