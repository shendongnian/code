        public class ClassProtected
            {
                public string CallingFunction(Customer customer)
                {
                    var firstName = ProtectedFunction(customer.FirstName);
                    var lastName = ProtectedFunction(customer.LastName);
                    return string.Format("{0}, {1}", lastName, firstName);
                }
                protected virtual string ProtectedFunction(string value)
                {
                    return value.Replace("SAP", string.Empty);
                }
            }
