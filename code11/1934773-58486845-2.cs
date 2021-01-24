    using System.Linq;
    ...
    // static: we don't want this in the method
    public static bool ValidateAccountNumber(string Accountnumber) {
      return // Not null 
             Accountnumber != null &&
             // Contains exactly 15 characters 
             Accountnumber.Length == 15 &&
             // All characters are digits
             Accountnumber.All(c => c >= '0' && c <= '9') &&
             // Doesn't start from 0, 1, 8, 9 
           !(new char [] {'0', '1', '8', '9'}.Any(c => c == Accountnumber[0]));
    }
      
