    public static class CustomerExtension
    {
        public static string DisplayCity(this Customer customer)
        {
            return customer.MailingAddress == null ? String.Empty : customer.MailingAddress.City
        }
    }
