    using NetMQ;
    using NetMQ.Sockets;
    using NUnit.Framework;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    namespace Tests
    {
        class NetMqTransportTests
        {
            [Test]
            public void TestMulticastNetMQ()
            {
                bool wasCalled = false;
    
                var coreEventbus = "tcp://localhost:12345";
    
                Task.Run(() =>
                {
                    using (var subSocket = new SubscriberSocket())
                    {
                        subSocket.Connect(coreEventbus);
                        subSocket.Subscribe("account");
    
                        while (true)
                        {
                            string messageTopicReceived = subSocket.ReceiveFrameString();
                            string messageReceived = subSocket.ReceiveFrameString();
    
                            Assert.IsTrue(messageReceived == "testing");
                            wasCalled = true;
                            break;
                        }
                    }
    
                });
    
                Thread.Sleep(TimeSpan.FromSeconds(1));
    
                using (var pubSocket = new PublisherSocket())
                {
                    pubSocket.Bind(coreEventbus);
    
                    Thread.Sleep(500);
                    pubSocket.SendMoreFrame("account").SendFrame("testing");
                }
    
                Thread.Sleep(TimeSpan.FromSeconds(5));
    
                Assert.IsTrue(wasCalled);
            }
        }
    }
