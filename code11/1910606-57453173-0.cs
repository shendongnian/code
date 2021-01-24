RootObject root = new RootObject
{
    UserL = RootObject.FromJson("json1.json")
};
The error you're getting is due to the format of the json you're trying to deseralise. Because you're deserialising directly into a list, not a class that contains a list, the outermost part needs to be an `[]` array.
Taking the json you posted as an example you need to remove the UserArr part and change
{  
   "UserArr":[  
      {  
         "Username":"User2",
         "UserID":307618173073489920,
         "WarnCount":0,
         "Level":0,
         "XP":0
      },
      {  
         "UserName":"User1",
         "UserID":385453321999089664,
         "WarnCount":0,
         "Level":0,
         "XP":0
      }
   ]
}
into
[  
   {  
      "Username":"User2",
      "UserID":307618173073489920,
      "WarnCount":0,
      "Level":0,
      "XP":0
   },
   {  
      "UserName":"User1",
      "UserID":385453321999089664,
      "WarnCount":0,
      "Level":0,
      "XP":0
   }
]
If the json is not modifiable then you could change how you deserialise. Rather than deserialising directly to the list, deserialise to the `RootObject` class. This will require you to rename the property `UserL` to be `UserArr` to match the json e.g.
public class RootObject
{
    public List<User> UserArr = new List<User>();
}
RootObject root = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText("json.json"));
and keeping with your `FromJson` method
public class RootObject
{
    public List<User> UserArr = new List<User>();
    public static RootObject FromJson(string json) => JsonConvert.DeserializeObject<RootObject>(File.ReadAllText(json));
}
RootObject root = RootObject.FromJson("json.json");
