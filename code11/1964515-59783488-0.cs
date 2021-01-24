    public string ReadMessages()
            {
                MQQueue mqDestination;
                String Readmessage = null;
                QueueManagerName = ConfigurationManager.AppSettings["QueueManagername"];
                Hashtable properties = new Hashtable();
                properties.Add(MQC.HOST_NAME_PROPERTY, ConfigurationManager.AppSettings["Connection"]);
                properties.Add(MQC.PORT_PROPERTY, ConfigurationManager.AppSettings["PortNo"]);
                properties.Add(MQC.CHANNEL_PROPERTY, ConfigurationManager.AppSettings["Channelname"]);            
                properties.Add(MQC.MQCA_TOPIC_NAME, ConfigurationManager.AppSettings["Queuename"]);
    
                properties.Add(MQC.TRANSPORT_PROPERTY, MQC.TRANSPORT_MQSERIES_MANAGED);
    
                try
                {
                queueManager = new MQQueueManager(QueueManagerName, properties);
    
                int openOptionsForGet = MQC.MQOO_INPUT + MQC.MQSO_FAIL_IF_QUIESCING;
    
                    //Queue Name
                    mqDestination = queueManager.AccessQueue(ConfigurationManager.AppSettings["QueueName"],openOptionsForGet);
    //Read messages with a wait of 30 seconds. Break out of the loop when there are no messages (MQRC 2033) or any other reason code is received.
    				while (true) {
    				  try {
    					MQGetMessageOptions Gmo = new MQGetMessageOptions();
                        Gmo.WaitInterval = 30
                        Gmo.Options |= MQC.MQGMO_WAIT;
    					MQMessage RetrievedMessage = new MQMessage();
    					mqDestination.Get(RetrievedMessage, Gmo);
    					string message = RetrievedMessage.ReadString(RetrievedMessage.MessageLength);
    				} catch(MQException ex) {
    					   // Display the exception and break;
    						break;
    					}
    				}
                    mqDestination.Close();
                    queueManager.Disconnect();
                }
                catch (MQException ex)
                {
                    switch (ex.ReasonCode)
                    {
                        case IBM.WMQ.MQC.MQRC_NO_MSG_AVAILABLE:
                            Library.ErrorLogs("error" + "No message available.");
                            break;
                        case IBM.WMQ.MQC.MQRC_Q_MGR_QUIESCING:
                        case IBM.WMQ.MQC.MQRC_Q_MGR_STOPPING:
                            Library.ErrorLogs("error" + "Queue Manager Stopping: " + ConfigurationManager.AppSettings["QueueManagername"] + "\t" + ex.Message);
                            break;
                        case IBM.WMQ.MQC.MQRC_Q_MGR_NOT_ACTIVE:
                        case IBM.WMQ.MQC.MQRC_Q_MGR_NOT_AVAILABLE:
                            Library.ErrorLogs("error" + "Queue Manager not available: " + ConfigurationManager.AppSettings["QueueManagername"] + "\t" + ex.Message);
                            break;
                        default:
                            Library.ErrorLogs("error" + " Error reading topic: " + ConfigurationManager.AppSettings["Queuename"] + "\t" + ex.Message);
                            break;
                    }
    
                }
                catch (Exception ex)
                {
                    // Console.WriteLine("MQException caught. " + mqE.ToString());
                    Library.ErrorLogs("error" + ex.Message);
                    queueManager.Disconnect();
    
                }
               return Readmessage;
    
    
            }
