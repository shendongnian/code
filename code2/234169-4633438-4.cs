    namespace Busker.Data.Commands.Message
    {
        public class CreateMessageCommand :Command
        {
    
    
            public CreateMessageCommand (int from, int to, string title, string body)
            {
                    // set private variable.. 
            }
    
    
            public override void Execute()
            {
    
                // Do your stuff here
    
    
                be.SaveChanges();
                this.Success = true;
    
            }
        }
    }
