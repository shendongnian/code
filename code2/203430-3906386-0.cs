    using System.Messaging;
    Message recoverableMessage = new Message();
    recoverableMessage.Body = "Sample Recoverable Message";
    recoverableMessage.Recoverable = true;
    MessageQueue msgQ = new MessageQueue(@".\$private\Orders");
    msgQ.Send(recoverableMessage);
