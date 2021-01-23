    public static string getLastNameCommaFirstName(String fullName) {
        List<string> names = fullName.Split(' ').ToList();
        string firstName = names.First();
        names.RemoveAt(0);
          
        return String.Join(" ", names.ToArray()) + ", " + firstName;            
    } 
