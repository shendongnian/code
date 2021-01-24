#region Fields
public enum JsonObjType 
{
	Application,
	Proxy,
	SomeController,
}
#endregion
#region Classes
// Application
public class AppObj : JsonObjMaster
{
	public readonly JsonObjType Type {get;}
	public int Duration {get; set;}
	public AppRequest Request {get; set;}
	public AppObjController Controller {get; set;}
	
	//you need a default constuctor for classes, cause else no json parser will work with them
	public AppObj()
	{
		Type = JsonObjType.Application;
		Duration = 0;
		AppResult = String.Empty;
		Request = new AppRequest();
		Controller = new AppObjController();
	}
}
public class AppObjController : JsonObjSlave
{
	public readonly JsonObjType Type {get;}
	public string[] Logs {get; set;}
	public Func</*whatever is supposed to be here*/> Method {get; set;}
	public AppResult Result {get; set;}
	
	public AppObjController()
	{
		Type = JsonObjType.SomeController;
		Log = Array.Empty<string>();
		Method = (/*whatever is supposed to be here*/) => null; //may need to change depending on what the function is for
		Result = new AppResult();
	}
}
// Proxy
public class ProxyObj : JsonObjMaster
{
	public readonly JsonObjType Type {get;}
	public int Duration {get; set;}
	public string Assembly {get; set;} 	//I am assuming strings here since no type is supplied
	public string Policy {get; set;}
	public string Cache {get; set;}
	public string Request {get; set;}
	public string WTFTYPEFUCKWHOEVERMADETHISJSON {get; set;}
	public string[] Logs {get; set;}
	public Func</*whatever is supposed to be here*/> Method {get; set}
	public string Response {get; set;}
	
	public ProxyObj()
	{
		Type = JsonObjType.Proxy;
		Duration = 0; //not needed but to stay consistent
		Assembly = String.Empty();
		Policy = String.Empty();
		Cache = String.Empty();
		Request = String.Empty();
		WTFTYPEFUCKWHOEVERMADETHISJSON = String.Empty();
		Logs = Array.Empty<string>();
		Method = (/*whatever is supposed to be here*/) => null; //may need to change depending on what the function is for
		Response = String.Empty();
	}
}
#endregion
#region Structs
// Interfaces
public interface JsonObjMaster
{
	public readonly JsonObjType Type {get;}
	public int Duration {get; set;}
}
public interface JsonObjSlave
{
	public readonly JsonObjType Type {get;}
}
// Structs
public struct IdEnrolment
{
	public string Username {get; set;}
	public string Password {get; set;}
	public bool CreateNewUser {get; set;}
}
public struct AppResult
{
	public int Code {get; set;}
	public string Title {get; set;}
	public string Message {get; set;}
}
public struct AppRequest
{
	public string AuthRefernece {get; set;}
	public IdEnrolment {get; set;}
}
#endregion
In order to load the JSON into the classes you now need to supply the parer with the names of the C# object properties in the context of the JSON file so that the parser can link them. This can look something like this:
[MyJsonparser.JsonName("Type")]
public string WTFTYPEFUCKWHOEVERMADETHISJSON {get; set;}
But it is highly dependant on the JSON lib you're using, so you need to look it up in their docs.
If you can sucsessfully convert the JSON fuckery that someone (hopefully not you) did into C# objects you can then **resolve the JSON strings that are left over by moving to another layer of classes and structs**, which you can then use for processing.
