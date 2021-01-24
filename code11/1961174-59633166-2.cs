cs
myMessage.message = new messageProperties
{
	messageBody = "Happy weekend",
	messageSubject = "Greetings"
};
instead of this
cs
//below code throws error System.NullReferenceException: 'Object reference not set to an instance of an object.'
//MyMessage.message.messageSubject = "Greetings";
//MyMessage.message.messageBody = "Happy weekend";
Then you'll be able to print it out successfully
cs
Console.WriteLine(myMessage.message.messageSubject);
prints 
> Greetings
Another option is to initialize nested properties in constructor, like that
cs
public class standardMessage
{
	public standardMessage()
	{
		message = new messageProperties();
		flag = new messageFlags();
	}
	public messageProperties message { get; set; }
	public messageFlags flag { get; set; }
}
Then you can assign the values like you want
cs
myMessage.message.messageSubject = "Greetings";
myMessage.message.messageBody = "Happy weekend";
Or you can finish you snippet and set the nested property directly
cs
standardMessage myMessage = new standardMessage();
messageProperties myMsgProperties = new messageProperties();
myMsgProperties.messageSubject = "Hey!";
myMsgProperties.messageBody = "Howdy";
myMessage.message = myMsgProperties;
Console.WriteLine(myMessage.message?.messageSubject);
Prints 
> Hey!
Null-conditional [operator][1] `?` will help you to avoid `NullReferenceException` if any
  [1]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/member-access-operators#null-conditional-operators--and-
