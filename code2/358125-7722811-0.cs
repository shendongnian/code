                    MQMessage message = new MQMessage();
                    message.SetBytesProperty("testBytesValue", new sbyte[] { 8, 12, 22, 48, 68, 71, 92, 104 });
                    message.WriteUTF(MessageContent);
                    queue.Put(message);
                    MQMessage readMessage = new MQMessage();
                    queue.Get(readMessage);
                    sbyte[] array = readMessage.GetBytesProperty("testBytesValue");
                    Console.Write(array);
