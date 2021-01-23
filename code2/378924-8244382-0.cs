    using System.Xml.Serialization;
    using System;
    
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class orders 
    {
        private ordersOrder orderField;
    
        public ordersOrder order 
        {
            get 
            {
                return this.orderField;
            }
            set 
            {
                this.orderField = value;
            }
        }
    }
    
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class ordersOrder 
    {
        
        private int ordersIDField;
        private double ordersTotalField;
        private ordersOrderProd[] prodField;
        
        public int ordersID 
        {
            get 
            {
                return this.ordersIDField;
            }
            set 
            {
                this.ordersIDField = value;
            }
        }
    
        public double ordersTotal 
        {
            get 
            {
                return this.ordersTotalField;
            }
            set 
            {
                this.ordersTotalField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute("prod")]
        public ordersOrderProd[] prod 
        {
            get 
            {
                return this.prodField;
            }
            set 
            {
                this.prodField = value;
            }
        }
    }
    
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class ordersOrderProd 
    {
        private int productCountField;
        private double productPriceField;
        private double productPricePromoField;
        private double productDiscountField;
        private string productNameField;
        private Int64 productNumberField;
        
        public int productCount 
        {
            get 
            {
                return this.productCountField;
            }
            set 
            {
                this.productCountField = value;
            }
        }
        
        public double productPrice 
        {
            get 
            {
                return this.productPriceField;
            }
            set 
            {
                this.productPriceField = value;
            }
        }
        
        public double productPricePromo 
        {
            get 
            {
                return this.productPricePromoField;
            }
            set 
            {
                this.productPricePromoField = value;
            }
        }
        
        public double productDiscount 
        {
            get 
            {
                return this.productDiscountField;
            }
            set 
            {
                this.productDiscountField = value;
            }
        }
        
        public string productName 
        {
            get 
            {
                return this.productNameField;
            }
            set 
            {
                this.productNameField = value;
            }
        }
        
        public Int64 productNumber 
        {
            get 
            {
                return this.productNumberField;
            }
            set 
            {
                this.productNumberField = value;
            }
        }
    }
