    class Constraint
    {
        double Lower; bool isLowerStrict;
        double Upper; bool isUpperStrict;
        bool isIn(double d)
        { 
            return (isLowerStrict ? Lower < d : Lower <= d) &&
                   (isUpperStrict ? Upper > d : Upper >= d);
        }
        Constraint intersect(Constraint other)
        {
            Constraint result = new Constraint();
            if (Lower > other.Lower)
            {
                result.Lower = Lower;
                result.isLowerStrict = isLowerStrict;
            }
            else if (Lower < other.Lower)
            {
                result.Lower = other.Lower;
                result.isLowerStrict = other.isLowerStrict;
            }
            else
            {
                result.Lower = Lower;
                result.IsLowerStrict = isLowerStrict || other.isLowerStrict;
            }
            // the same for upper
            return result;
        }
        
        public bool isEmpty()
        {
            if (Lower > Upper) return true;
            if (Lower == Upper && (isLowerStrict || isUpperStrict)) return true;
            return false;
        }
        public bool Equals(Constraint other)
        {
            if (isEmpty()) return other.isEmpty();
            return (Lower == other.Lower) && (Upper = other.Upper) &&
                   (isLowerStrict == other.IsLowerStrict) &&
                   (isUpperStrict == other.isUpperStrict);
        }
        // construction:
        static Constraint GreaterThan(double d)
        {
            return new Constraint()
            {
                Lower = d,
                isLowerStrict = true,
                Upper = double.PositiveInfinity,
                isUpperStrict = false
            }
        }
        // etc.
    }
