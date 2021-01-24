csharp
interface IMessage<TContent>
{
    TContent Content { get; }
    User Sender { get; }
    DateTime Sent { get; }
}
public class FileMessage : IMessage<File>
{
   ...
}
public class StringMessage : IMessage<string>
{
   ...
}
// etc
Advantage: always strongly typed  
Disadvantage: you now can't have (say) a `List<IMessage>`. You could mitigate this by separating out the non-generic and generic parts:
csharp
interface IMessage
{
    User Sender { get; }
    DateTime Sent { get; }
}
interface IMessage<TContent> : IMessage
{
    TContent Content { get; }
}
**Option 2: use explicit interface implementation**
csharp
interface IMessage
{
    object Content { get; }
    User Sender { get; }
    DateTime Sent { get; }
}
public class FileMessage : IMessage
{
    // Explicit interface implementation of the object-typed Content property 
    object IMessage.Content => Content;
    // Regular strongly-typed property for Content
    public File Content { get; }
    // Other interface properties
}
// etc
Advantage: No need for generics  
Disadvantage: Weakly-typed access to content when using the interface, and slightly more complicated code.
