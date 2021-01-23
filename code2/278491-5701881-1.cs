        public class Customer : BusinessObject
    {
    }
    public class SalesOrder : BusinessObject
    {
        
        /// <summary>
        /// The type this SalesOrder is for.
        /// </summary>
        [AutoMapCompulsory]
        public virtual Customer Customer
        {
            get { return Relationships.GetRelatedObject<Customer>("Customer"); }
            set { Relationships.SetRelatedObject("Customer", value); }
        }
    }
