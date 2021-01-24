c#
[Serializable]
public class User
{
    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DOB { get; set; }
    public override string ToString()
    {
        return $"{ID}, {FirstName}, {LastName}, {DOB.ToShortDateString()}";
    }
}
**Create the _Users_ class**
Another _Serializable_ class contains a list of `User` objects and handles both serialize and Deserialize routines:
c#
[Serializable]
public class Users  
{
    public List<User> ThisUsers = new List<User>();
    public void Save(string filePath)
    {
        XmlSerializer xs = new XmlSerializer(typeof(Users));
        using (StreamWriter sr = new StreamWriter(filePath))
        {
            xs.Serialize(sr, this);
        }
    }
    public static Users Load(string filePath)
    {
        Users users;
        XmlSerializer xs = new XmlSerializer(typeof(Users));
        using (StreamReader sr = new StreamReader(filePath))
        {
            users = (Users)xs.Deserialize(sr);
        }
        return users;
    }
}
This way, you guarantee the XML file is formatted correctly, manage the users list (add, remove, edit).
**Save (serialize) example**
c#
string filePath = @"TextFiles/Users.txt";
Users users = new Users();
for (int i = 1; i < 5; i++)
{
    User u = new User
    {
        ID = i,
        FirstName = $"User {i}",
        LastName = $"Last Name {i}",
        DOB = DateTime.Now.AddYears(-30 + i)                    
    };
    users.ThisUsers.Add(u);
}
users.Save(filePath);
**Load (Deserialize) example:**
c#
string filePath = @"TextFiles/Users.txt";
Users users = Users.Load(filePath);
users.ThisUsers.ForEach(a => Console.WriteLine(a.ToString()));
//Or get a specific user by id:
Console.WriteLine(users.ThisUsers.Where(b => b.ID == 3).FirstOrDefault()?.ToString());
and here is how the generated XML file looks like
xml
<?xml version="1.0" encoding="utf-8"?>
<Users xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <ThisUsers>
    <User>
      <ID>1</ID>
      <FirstName>User 1</FirstName>
      <LastName>Last Name 1</LastName>
      <DOB>1990-11-04T08:16:09.1099698+03:00</DOB>
    </User>
    <User>
      <ID>2</ID>
      <FirstName>User 2</FirstName>
      <LastName>Last Name 2</LastName>
      <DOB>1991-11-04T08:16:09.1109688+03:00</DOB>
    </User>
    <User>
      <ID>3</ID>
      <FirstName>User 3</FirstName>
      <LastName>Last Name 3</LastName>
      <DOB>1992-11-04T08:16:09.1109688+03:00</DOB>
    </User>
    <User>
      <ID>4</ID>
      <FirstName>User 4</FirstName>
      <LastName>Last Name 4</LastName>
      <DOB>1993-11-04T08:16:09.1109688+03:00</DOB>
    </User>
  </ThisUsers>
</Users>
Good luck.
