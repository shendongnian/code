    firstCollection.Intersect(
                  secondCollection, 
                  new LambdaComparer<YourClass>(
                      (item1, item2) => item1.PropertyName == item2.PropertyName));
     // Below are lists and User class which demonstrates LambdaComparer and Intersect()
     public class User
     {
          public string Name { get; set; }
     }
    
     IList<User> list1 = new List<User> 
           { 
              new User {Name = "A"}, 
              new User { Name = "B"}
           };
     List<User> list2 = new List<User> 
          { 
              new User {Name = "C"}, 
              new User { Name = "B"}
          };
     var resultSet = list1.Intersect<User>(
             list2, 
             new LambdaComparer<User>((item1, item2) => item1.Name == item2.Name));
    
