    public class NewUserCommand : ConsoleCommand
    {
        public override void Process(Context context, string command)
        {
            if (context.User != null)
            {
                // different greetings based on acess level
                if (context.Received.Message == "has entered this room")
                {
                    if (context.User == null)
                    {
                        SendToChat("/w " + context.Received.Username + " " + context.Received.Username + " you have no registration.");
                        Thread.Sleep(1000);
                        SendToChat("/kick " + context.Received.Username + " not registered.");
                        Thread.Sleep(1000);
                        //I could process the request
                        return;
                    }
                }
            }
            //I dont know what to do, continue with the next processor
            this.Successor.Process(context, command);
        }
    }
