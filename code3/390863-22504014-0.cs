    using Castle.Core.Internal;
    namespace PhoneNumbers
    {
        public class PhoneNumberService : IPhoneNumberService
        {
            public void ConsolidateNumbers(Account accountRequest)
            {
                if (accountRequest.Addresses.IsNullOrEmpty()) // Addresses is List<T>
                {
                    return;
                }
                ...
