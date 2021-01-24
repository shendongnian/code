    internal class NumberDetailsComparer : IEqualityComparer<NumberDetails>
    {
        public bool Equals(NumberDetails x, NumberDetails y)
        {
            if (\* Set of conditions for equality matching *\)
            {
                return true;
            }
            return false;
        }
     
        public int GetHashCode(Student obj)
        {
            return obj.Name.GetHashCode(); // Name or whatever unique property
        }
    } 
