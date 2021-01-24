    public class myClass : IComparable
    {
        public String delivery;
        public String articleCode;
        public String dex;
        public String phase;
        public String quantity;
    
        // Order by delivery datetime
        public int CompareTo(object obj)
        {
            if (obj.GetType() != typeof(myClass ) || (obj.delivery == delivery))
                return 0;
            
            DateTime dtDelivery = DateTime.ParseExact(delivery, "dd-MM-yyyy");
            DateTime dtObjDelivery = DateTime.ParseExact((obj as myClass).delivery, "dd-MM-yyyy");
            return dt.Delivery.CompareTo(dtObjDelivery);
        }
    }
