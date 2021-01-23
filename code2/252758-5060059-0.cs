    public override int GetHashCode()
    {
        unchecked
        {
            int result = 37; // prime
            result *= 397; // also prime (see note)
            if (str1 != null)
                result += str1.GetHashCode();
            result *= 397;
            if (str2 != null)
                result += str2.GetHashCode();
            result *= 397;
            if (str2 != null)
                result += str2.GetHashCode();
            return result;
        }
    }
