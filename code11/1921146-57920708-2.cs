    using System.Linq;
    ... 
    // Simplest, some names like 
    // "Charles de Batz de Castelmore d'Artagnan" 
    // does not pass
    private static bool IsValidName(string value) {
      return
        !string.IsNullOrEmpty(value) &&              // value can't be null or "" 
         value.All(letter => char.IsLetter(letter)); // All letters validation
    }
