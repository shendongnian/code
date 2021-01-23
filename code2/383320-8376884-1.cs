    Dictionary<string, User> reverseLookUp = new Dictionary<string, User>();
    User user;
    
    // Fill dictionary
    user = new User { Name = "John", Address = "Baker Street", PhoneNumber = "012345" };
    reverseLookUp.Add(user.PhoneNumber, user);
    user = new User { Name = "Sue", Address = "Wall Street", PhoneNumber = "333777" };
    reverseLookUp.Add(user.PhoneNumber, user);
    
    // Search a user
    string phoneNumber = "012345";
    if (reverseLookUp.TryGetValue(phoneNumber, out user)) {
    	Console.WriteLine("{0}, {1}, phone {2}", user.Name, user.Address, user.PhoneNumber);
    } else {
    	Console.WriteLine("User with phone number {0} not found!", phoneNumber);
    }
    
    // List all users
    foreach (User u in reverseLookUp.Values) {
    	Console.WriteLine("{0}, {1}, phone {2}", u.Name, u.Address, u.PhoneNumber);
    }
