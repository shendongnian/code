public Interface UserInfo
{
    string AS {get; set;}
    string BS {get; set;}
}
You can still use a base class, it must be the first one in the list i.e. after the ":".
public class UserData: UserInfo
public class User: UserInfo
Since BOTH classes **already** implement the Interface there is no changes other than deriving them from the interface.
Edit
---
Since the `UserData` class cannot be modified (for whatever reason, externally defined or publicly exposed through and `API`) and is not `sealed`, it is possible to derive a class from it and add the interface:
public class UserData1: UserData, UserInfo
{
// since the base class already implements the public properties as defined 
// in the interface, no implementation is required here
// however any defined constructors in the base class must be present here:
    // repeat per constructor
    public UserData1() : base() // add parameters: UserData1(int i):base(i)
    {
      // this can be left empty
    }
}
A completely fictional use case:
Assumes:
 `BusinessLogic.UserData` is passed in to the method as:
`List<BusinessLogic.UserData> userData`. and a single BusinessLogic.UserData value for completeness.
A class level array, already instantiated and populated, is available as `public User[] users`.
 This also requires `using System.Linq;" for the bulk type conversion.
public void ProcessAll(List<BusinessLogic.UserData> userData,BusinessLogic.UserData single)
{
   List<UserInfo> AllData = new List<UserInfo>();
   
   AllData.AddRange(userData.ConvertAll(new Converter<BusinessLogic.UserData, UserInfo>(i => i as UserData1))); 
   AllData.AddRange(users);
   // cast the single and add it to the list
   AllData.Add((UserInfo)((UserData1)single));// note the extra cast
   foreach(var user in AllData)
   {      
 //note CS is not available from AllData since it is not defined in the interface
      // not the most elegant code, but proves the point
      Console.WriteLine("AS=" + user.AS + " BS=" + user.BS);
   }
   //Let us replace the first element in userData with itself from AllData does nothing, but shows how to do this.
   if(AllData[0] is BusinessLogic.UserData)
//since add order is maintained in a list this if is not needed.
      userData[0] = (BusinessLogic.UserData)AllData[0];
   // since BusinessLogic.UserData is a reference type(class not struct) we can modify CS, but only if it is cast back to BusinessLogic.UserData first
   if(AllData[0] is BusinessLogic.UserData)
         ((BusinessLogic.UserData)AllData[0]).CS="Hello World";
}
