        public class EqualityComparer : IEqualityComparer<Employee >
        {
            #region IEqualityComparer<Village> Members
            bool IEqualityComparer<Employee>.Equals(Employee x, Employee y)
            {
                // Check whether the compared objects reference the same data.
                if (Object.ReferenceEquals(x, y))
                    return true;
                // Check whether any of the compared objects is null.
                if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                    return false;
                return x.Salary == y.Salary;
            }
            int IEqualityComparer<Employee>.GetHashCode(Employee obj)
            {
                return obj.Salary.GetHashCode();
            }
            #endregion
        }
