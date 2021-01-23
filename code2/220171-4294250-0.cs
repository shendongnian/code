    string usersXml = @"<users><user id=""50""><username>testuser</username></user><user id=""51""><username>jamie_user</username></user></users>";
    XElement doc = XElement.Parse(usersXml);
    // LINQ query syntax for find and removal
    // Add reference to System.Xml.Linq and add using System.Xml.Linq and using System.Linq
    var matchingUsers = from user in doc.Elements("user")
                        where (string)user.Attribute("id") == "50"
                        select user;
    // remvoing the users
    matchingUsers.Remove();
    // another way to find the users...
    doc = XElement.Parse(usersXml); // reload for demo
    var matchingUsers2 = doc.Elements("user").Select(
        xUser => (string)xUser.Attribute("id") == "50");
    // change the name
    doc = XElement.Parse(usersXml); // reload for demo
    matchingUsers = from user in doc.Elements("user")
                    where (string)user.Attribute("id") == "50"
                    select user;
    
    // replacing the name ...
    foreach (var user in matchingUsers)
    {
        var usernameElement = user.Element("username");
        if (usernameElement != null) {
            usernameElement.SetValue("newUserName");
        }                
    }
