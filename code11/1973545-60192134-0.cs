    void testCommitBackout()
            {
                string hostName = "localhost";
                int port = 1414;
                string channelName = "SVRCONN_CHN";
                string queueName = "QU1";
                int numberOfMsgs = 10;
                string queueManagerName = "QM1";
                int queueOpenOptionsForPut = MQC.MQOO_OUTPUT + MQC.MQOO_FAIL_IF_QUIESCING;
                int queueOpenOptionsForGet = MQC.MQOO_INPUT_AS_Q_DEF + MQC.MQOO_FAIL_IF_QUIESCING;
                string messageString = "Bunyamin Test";
                MQQueue queue;
            Hashtable properties = new Hashtable();
            properties.Add(MQC.TRANSPORT_PROPERTY, MQC.TRANSPORT_MQSERIES_MANAGED);
            properties.Add(MQC.HOST_NAME_PROPERTY, hostName);
            properties.Add(MQC.PORT_PROPERTY, port);
            properties.Add(MQC.CHANNEL_PROPERTY, channelName);
            properties.Add(MQC.USER_ID_PROPERTY, "myuserid");
            properties.Add(MQC.PASSWORD_PROPERTY, "Mylongpassword");
            // PUT MESSAGES
            var queueManager = new MQQueueManager(queueManagerName, properties);
            queue = queueManager.AccessQueue(queueName, queueOpenOptionsForPut);
            // putting messages continuously under a syncpoint and commit after that
            for (var i = 1; i <= numberOfMsgs; i++)
            {
                var mqpmo = new MQPutMessageOptions();
                mqpmo.Options |= MQC.MQPMO_SYNCPOINT;
                var message = new MQMessage();
                message.WriteString(messageString);
                System.Console.Write("Message " + i + " <" + messageString + ">.. ");
                queue.Put(message, mqpmo);
                System.Console.WriteLine("put");
            }
            // Now commit all 10 messages.
            queueManager.Commit();
            queue.Close();
            queueManager.Disconnect();
            //GET MESSAGES
            queueManager = new MQQueueManager(queueManagerName, properties);
            queue = queueManager.AccessQueue(queueName, queueOpenOptionsForGet);
            // Get messages under syncpoint 
            for (var i = 1; i <= numberOfMsgs; i++)
            {
                // creating a message object
                var message = new MQMessage();
                var gmo = new MQGetMessageOptions();
                gmo.Options |= MQC.MQGMO_SYNCPOINT;
                queue.Get(message, gmo);
                System.Console.WriteLine(i + " .Message " + i + " got = " +
                message.ReadString(message.MessageLength));
                message.ClearMessage();
            }
            // Backout all messages.
            queueManager.Backout(); //I EXPECT 10 MESSAGES SHOULD GO BACK TO QUEUE?
            queue.Close();
            queueManager.Disconnect();
        }
