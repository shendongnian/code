    public class MyServer
    {
         Dictionary<int, ICommandHandler> _handlers;
         public void Register(int functionId, ICommandHandler handler)
         {
              _handlers[functionId] = handler;
         }
         private void _Response()
         {
               // .. alot of stuff ..
               _handlers[reply].Handle(memoryStream);
 
         }
