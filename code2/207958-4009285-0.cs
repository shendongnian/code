    //The hashcode for a double is the absolute value of the integer representation
    //of that double.
    // 
    [System.Security.SecuritySafeCritical]  // auto-generated
    public unsafe override int GetHashCode() { 
        double d = m_value; 
        if (d == 0) {
            // Ensure that 0 and -0 have the same hash code 
            return 0;
        }
        long value = *(long*)(&d);
        return unchecked((int)value) ^ ((int)(value >> 32)); 
    }
