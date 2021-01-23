    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    using Apache.NMS;
    using Apache.NMS.ActiveMQ;
    using Apache.NMS.ActiveMQ.Commands;
    
    namespace Utilities
    {
        public delegate void QMessageReceivedDelegate(string message);
        public class MyQueueSubscriber : IDisposable
        {
            private readonly string topicName = null;
            private readonly IConnectionFactory connectionFactory;
            private readonly IConnection connection;
            private readonly ISession session;
            private readonly IMessageConsumer consumer;
            private bool isDisposed = false;
            public event QMessageReceivedDelegate OnMessageReceived;
    
            public MyQueueSubscriber(string queueName, string brokerUri, string clientId)
            {
                this.topicName = queueName;
                this.connectionFactory = new ConnectionFactory(brokerUri);
                this.connection = this.connectionFactory.CreateConnection();
                this.connection.ClientId = clientId;
                this.connection.Start();
                this.session = connection.CreateSession();
                ActiveMQQueue topic = new ActiveMQQueue(queueName);
                //this.consumer = this.session.CreateDurableConsumer(topic, consumerId, "2 > 1", false);
                this.consumer = this.session.CreateConsumer(topic, "2 > 1");
                this.consumer.Listener += new MessageListener(OnMessage);
    
            }
    
            public void OnMessage(IMessage message)
            {
                ITextMessage textMessage = message as ITextMessage;
                if (this.OnMessageReceived != null)
                {
                    this.OnMessageReceived(textMessage.Text);
                }
            }
    
            #region IDisposable Members
    
            public void Dispose()
            {
                if (!this.isDisposed)
                {
                    this.consumer.Dispose();
                    this.session.Dispose();
                    this.connection.Dispose();
                    this.isDisposed = true;
                }
            }
    
            #endregion
    
        }
    }
