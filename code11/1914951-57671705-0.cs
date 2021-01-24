csharp
using Akka.Actor;
using Akka.TestKit.Xunit;
using NSubstitute;
using System;
using Xunit;
namespace ActorTests
{
    public class TestSelfActor : UntypedActor
    {
        protected override void OnReceive(object message)
        {
            switch (message)
            {
                case string s:
                    if (s == "1")
                    {
                        Console.WriteLine("one");
                        this.Self.Tell("2");
                        this.Sender.Tell("test");
                    }
                    else if (s == "2") { Console.WriteLine("two"); }
                    break;
            }
        }
    }
    public interface IMessageHandler
    {
        Func<object, bool> AroundReceiveHandler { get; }
    }
    public class FakeActor : TestSelfActor
    {
        private readonly IMessageHandler _messageHandler;
        public FakeActor(IMessageHandler messageHandler)
        {
            _messageHandler = messageHandler;
        }
        protected override bool AroundReceive(Receive receive, object message)
        {
            var acceptMessage = _messageHandler?.AroundReceiveHandler?.Invoke(message) ?? true;
            return acceptMessage && base.AroundReceive(receive, message);
        }
    }
    public class SelfActorSpecs : TestKit
    {
        [Fact]
        public void When_Sender_TellsOne_Actor_Should_RespondWith_Test_NotSending_Two_ToSelf()
        {
            var messageHandler = Substitute.For<IMessageHandler>();
            messageHandler.AroundReceiveHandler(Arg.Any<string>()).Returns(true);
            messageHandler.AroundReceiveHandler("2").Returns(false);
            var target = Sys.ActorOf(Props.Create(() => new FakeActor(messageHandler)));
            target.Tell("1");
            ExpectMsg<string>(x => x == "test");
        }
    }
}
