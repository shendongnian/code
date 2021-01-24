var simpleCereal = Newtonsoft.Json.JsonConvert.SerializeObject(new { user.Username, user.Password, UserGroups = user.Usergroups.Select(ug => new { ug.AccessRights, ug.Name, ug.Screen }).ToList() });
> Even though we used anonymous types, the serialization result will still deserialize back into a valid `User` object if you specify to ignore the missing members in the JsonSerializerSettings  
> `new JsonSerializerSettings { MissingMemberHandling = MissingMemberHandling.Ignore });`
We can achieve the syntax that you have suggested through a simple helper method that accepts a lambda:
/// <summary>
/// Serialize an object through a lambda expression that defines the expected output structure
/// </summary>
/// <typeparam name="T">Type of the object to serialize</typeparam>
/// <param name="target">The target object to serialize</param>
/// <param name="expr">The lambda expression that defines the final structure of the serialized object</param>
/// <returns>Serialized lambda representation of the target object</returns>
public static string Serialize<T>(T target, System.Linq.Expressions.Expression<Func<T, object>> expr)
{
    var truncatedObject = expr.Compile().Invoke(target);
    return Newtonsoft.Json.JsonConvert.SerializeObject(truncatedObject);
}
Your syntax is now supported:
string lambdaCereal = Serialize(user, u => new { u.Username, u.Password, UserGroups = u.Usergroups.Select(ug => new { ug.AccessRights, ug.Name, ug.Screen }).ToList() });
The following is the code that I used to test this, OPs class definitions have been omitted, you can find them in the question.
static void Main(string[] args)
{
    User user = new User
    {
        Username = "Test User",
        Password = "Password",
        Usergroups = new List<Usergroup>
        {
            new Usergroup
            {
                Name = "Group12", AccessRights = new List<AccessRight>
                {
                    new AccessRight { AccessLevel = 1 },
                    new AccessRight { AccessLevel = 2 }
                },
                Screen = new Screen { Name = "Home" },
                Users = new List<User>
                {
                    new User { Username = "Other1" },
                    new User { Username = "Other2" }
                }
            },
            new Usergroup
            {
                Name = "Group3Only", AccessRights = new List<AccessRight>
                {
                    new AccessRight { AccessLevel = 3 },
                },
                Screen = new Screen { Name = "Maintenance" },
                Users = new List<User>
                {
                    new User { Username = "Other1" },
                    new User { Username = "Other2" }
                }
            }
        }
    };
    // Standard deep serialization, will include the deep User objects within the user groups.
    var standardCereal = Newtonsoft.Json.JsonConvert.SerializeObject(user);
    // Simple anonymous type serialize, exclude Users from within UserGroups objects
    var simpleCereal = Newtonsoft.Json.JsonConvert.SerializeObject(new { user.Username, user.Password, UserGroups = user.Usergroups.Select(ug => new { ug.AccessRights, ug.Name, ug.Screen }).ToList() });
    // Same as above but uses a helper method that accepts a lambda expression
    var lambdaCereal = Serialize(user, u => new { u.Username, u.Password, UserGroups = u.Usergroups.Select(ug => new { ug.AccessRights, ug.Name, ug.Screen }).ToList() });
    // NOTE: simple and lambda serialization results will be identical. 
    // deserialise back into a User
    var userObj = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(
        lambdaCereal, 
        new Newtonsoft.Json.JsonSerializerSettings
        {
            MissingMemberHandling = Newtonsoft.Json.MissingMemberHandling.Ignore
        });
}
/// <summary>
/// Serialize an object through a lambda expression that defines the expected output structure
/// </summary>
/// <typeparam name="T">Type of the object to serialize</typeparam>
/// <param name="target">The target object to serialize</param>
/// <param name="expr">The lambda expression that defines the final structure of the serialized object</param>
/// <returns>Serialized lambda representation of the target object</returns>
public static string Serialize<T>(T target, System.Linq.Expressions.Expression<Func<T, object>> expr)
{
    var truncatedObject = expr.Compile().Invoke(target);
    return Newtonsoft.Json.JsonConvert.SerializeObject(truncatedObject);
}
> In the above code `simpleCereal == lambdaCereal` => `true`
lambdaCereal results in this:
 json
{
  "Username": "Test User",
  "Password": "Password",
  "UserGroups": [
    {
      "AccessRights": [
        {
          "AccessLevel": 1
        },
        {
          "AccessLevel": 2
        }
      ],
      "Name": "Group12",
      "Screen": {
        "Name": "Home"
      }
    },
    {
      "AccessRights": [
        {
          "AccessLevel": 3
        }
      ],
      "Name": "Group3Only",
      "Screen": {
        "Name": "Maintenance"
      }
    }
  ]
}
> You mentioned that you are using nhibernate, if the object is not yet materialised in memory, then if you do not expand the `Users` property on the `UserGroups` expansion (and therefor not eagerly load the `Users` property), then it will not be included in the serialization output.
