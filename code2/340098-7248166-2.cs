    using Microsoft.Deployment.WindowsInstaller;
    namespace CustomAction1
    {
        public class CustomActions
        {
            [CustomAction]
            public static ActionResult ActionName(Session session)
            {
                try
                {
                    session.Log("Custom Action beginning");
                
                    // Do Stuff...
                    if (cancel)
                    {
                        session.Log("Custom Action cancelled");
                        return ActionResult.Failure;
                    }
    
                    session.Log("Custom Action completed successfully");
                    return ActionResult.Success;
                }
                catch (SecurityException ex)
                {
                    session.Log("Custom Action failed with following exception: " + ex.Message);
                    return ActionResult.Failure;
                }
             }
        }
    }
