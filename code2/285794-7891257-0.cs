    public partial class InvoiceHeaders
    {
        public string CustomerName
        {
            get
            {
                try
                {
                    return this.Customer.Name;
                }
                catch
                {
                    return string.Empty;
                }
            }
            private set { }
        }
    }
