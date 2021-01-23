        public class BusinessDivision : BusinessObject
        {
            [SecuredOperation("Manager")]
            public void EnlistEmployee(Employee employee)
            {
                // Details omitted.
            }
        }
