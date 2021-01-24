    public class Additionaldata
    {
        public string postimezone { get; set; }
        public string posstaffexternalid { get; set; }
    }
    
    public class Orderitem
    {
        public int orderitemid { get; set; }
        public int orderitemtype { get; set; }
        public int productid { get; set; }
        public string productname { get; set; }
        public string sku { get; set; }
        public string productattributes { get; set; }
        public string externalinput { get; set; }
        public string externalinputtitle { get; set; }
        public string unitlabel { get; set; }
        public int quantity { get; set; }
        public object decimalunitquantity { get; set; }
        public string moneynetpriceperunit { get; set; }
        public string moneypriceorg { get; set; }
        public int vatvalue { get; set; }
        public string deliveryinfo { get; set; }
        public string moneyitemtotal_net { get; set; }
        public string moneyitemtotal_vat { get; set; }
        public int voucherid { get; set; }
        public string vouchercode { get; set; }
        public string vouchername { get; set; }
        public string moneyoriginalprice { get; set; }
        public string moneydiscountedprice { get; set; }
        public string moneydiscount { get; set; }
        public List<object> salestaxes { get; set; }
        public Additionaldata additionaldata { get; set; }
        public string decimalquantitytotal { get; set; }
        public string moneynetpriceperquantity { get; set; }
    }
    
    public class Item
    {
        public int orderid { get; set; }
        public string email { get; set; }
        public string namefirst { get; set; }
        public string namelast { get; set; }
        public string company { get; set; }
        public string moneyfinal_net { get; set; }
        public string moneyfinal_vat { get; set; }
        public string moneytotal_gross_roundoff { get; set; }
        public string moneytotal_gross_all { get; set; }
        public string checkouttypename { get; set; }
        public string deliverytypename { get; set; }
        public int orderdate { get; set; }
        public int orderstateid { get; set; }
        public int paymentstateid { get; set; }
        public int ordertypeid { get; set; }
        public string registerid { get; set; }
        public int warehouseid { get; set; }
        public object datereserved { get; set; }
        public string currencycode { get; set; }
        public Additionaldata additionaldata { get; set; }
        public List<Orderitem> orderitems { get; set; }
    }
    
    public class RootObject
    {
        public int totalcount { get; set; }
        public List<Item> items { get; set; }
    }
