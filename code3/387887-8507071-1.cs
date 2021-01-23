    public class MySaga : Saga<MySagaData>, IAmStartedByMessages<Message1>
    {
        public override void ConfigureHowToFindSaga()
        {
             ConfigureMapping<Message1>(s => s.SomeID, m => m.SomeID);
        }
        public void Handle(Message1 message)
        {
           if(Data.Id != Guid.Empty)
           {
               // handle existing saga
           }
           else // create new saga instance
           {
              this.Data.SomeID = message.SomeID;
              RequestUtcTimeout(DateTime.Now.AddHours(23), "End of batch");
           }
            // rest of the code to handle Message1
        }
        public override void Timeout(object state)
        {
            // some business action
        } 
    }
