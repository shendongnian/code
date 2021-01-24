csharp
public class Message
{
   public string title;
   public string content;
}
public class ConfiguredMessage : Message 
{
   IMessageConfiguration configuration { get; set; }
}
public interface IMessageConfiguration
{
   void readMessage();
}
public class AudibleMessageConfiguration: IMessageConfiguration
{
   public void ReadMessage()
   {
      // play audio message on speaker?
   }
   public AudioConfiguration audioConfiguration { get; set; }
}
public class AutomaticMessageConfiguration : IMessageConfiguration
{
   public void ReadMessage()
   {
      // execute automated actions?
   }
   public MessageAutomatization messageAutomatization { get; set; }
}
I hope it is useful and if there are any misunderstandings or mistakes in my logic please let me know.
