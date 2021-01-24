     public string Name {
       get {
         return Id.HasValue
           ? $"{Id}/{Code}"
           : ""; // often, it's to better return an empty string, not null
       }
       set {
         if (string.IsNullOrEmpty(value)) {
           Id = null;
           Code = ""; // often, it's to better return an empty string, not null
         } 
         else {
           string[] parts = string.Split(new char[] {'/'}, 2);
           if (string.IsNullOrEmpty(parts[0])) {
             Id = null;
             Code = parts.Length > 1 ? parts[1] : ""; 
           }
           else if (int.TryParse(parts[0], out int id)) {
             Id = id;
             Code = parts.Length > 1 ? parts[1] : ""; 
           } 
           else 
             throw new FormatException("Name is inincorrect format.");
         }
       }
     }   
