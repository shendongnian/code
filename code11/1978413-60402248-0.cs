var users = await graphServiceClient.Users.Request().GetAsync(); 
var userFilter =     users 
                    .Select(u => number ? string.Join(", ", u.BusinessPhones) : u.DisplayName) 
                    .Where(condit => condit.Contains("154")).ToList();
                    
userFilter.ForEach(x => Console.WriteLine(x)); 
