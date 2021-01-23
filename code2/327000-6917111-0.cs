    public class TemperatureMeter {
       private AutoResetEvent _signal = new AutoResetEvent(false);
    
       public TemperatureMeter {
         CommunicationService.AddHandler(HandlePotentialTemperatureResponse);
       }
    
       public bool HandlePotentialTemperatureResponse(Response response) {
         // if response is what I'm looking for
         _signal.Set();
        
         // store the result in a queue or something =)
       }
    
       public decimal ReadTemperature() {
         CommunicationService.SendCommand(Commands.ReadTemperature);
         _signal.WaitOne(Commands.ReadTemperature.TimeOut); // or smth like this
    
         return /* dequeued value from the handle potential temperature response */;
       }
    
    }
