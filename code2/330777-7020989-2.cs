    public class CustomActions
    {
        [CustomAction]
        public static ActionResult CustomAction1(Session session)
        {
            session.Log("Begin CustomAction1");
    
            var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\MSMQ");
            session["MSMQ_INSTALLED"] = key == null ? "-1" : "1";
    
            return ActionResult.Success;
    
        }
    }
