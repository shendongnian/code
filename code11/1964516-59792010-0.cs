    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Text;
    using IBM.WMQ;
    
    /// <summary> Program Name
    /// MQTest72
    ///
    /// Description
    /// This C# class will connect to a remote queue manager
    /// and get messages from a queue using a managed .NET environment.
    ///
    /// </summary>
    /// <author>  Roger Lacroix
    /// </author>
    namespace MQTest72
    {
       class MQTest72
       {
          private Hashtable qMgrProp = null;
          private System.String qManager;
          private System.String inputQName;
    
          /*
          * The constructor
          */
          public MQTest72()
             : base()
          {
          }
    
          /// <summary> Make sure the required parameters are present.</summary>
          /// <returns> true/false
          /// </returns>
          private bool allParamsPresent()
          {
             bool b = false;
    
             if ( (ConfigurationManager.AppSettings["ConnectionName"] != null) &&
                  (ConfigurationManager.AppSettings["Port"] != null) &&
                  (ConfigurationManager.AppSettings["ChannelName"] != null) &&
                  (ConfigurationManager.AppSettings["QMgrName"] != null) &&
                  (ConfigurationManager.AppSettings["QueueName"] != null) )
             {
                try
                {
                   System.Int32.Parse(ConfigurationManager.AppSettings["Port"]);
                   b = true;
                }
                catch (System.FormatException e)
                {
                   b = false;
                }
             }
    
             return b;
          }
    
          /// <summary> Extract the configuration applicaiton settings and initialize the MQ variables.</summary>
          /// <param name="args">
          /// </param>
          /// <throws>  IllegalArgumentException </throws>
          private void init(System.String[] args)
          {
             if (allParamsPresent())
             {
                qManager = ConfigurationManager.AppSettings["QMgrName"];
                inputQName = ConfigurationManager.AppSettings["QueueName"];
    
                qMgrProp = new Hashtable();
                qMgrProp.Add(MQC.TRANSPORT_PROPERTY, MQC.TRANSPORT_MQSERIES_MANAGED);
    
                qMgrProp.Add(MQC.HOST_NAME_PROPERTY, ConfigurationManager.AppSettings["ConnectionName"]);
                qMgrProp.Add(MQC.CHANNEL_PROPERTY, ConfigurationManager.AppSettings["ChannelName"]);
    
                try
                {
                   qMgrProp.Add(MQC.PORT_PROPERTY, System.Int32.Parse(ConfigurationManager.AppSettings["Port"]));
                }
                catch (System.FormatException e)
                {
                   qMgrProp.Add(MQC.PORT_PROPERTY, 1414);
                }
    
                if (ConfigurationManager.AppSettings["UserId"] != null)
                   qMgrProp.Add(MQC.USER_ID_PROPERTY, ConfigurationManager.AppSettings["UserId"]);
    
                if (ConfigurationManager.AppSettings["Password"] != null)
                   qMgrProp.Add(MQC.PASSWORD_PROPERTY, ConfigurationManager.AppSettings["Password"]);
    
                logger("Parameters:");
                logger("  QMgrName ='" + qManager + "'");
                logger("  Queue Name ='" + inputQName + "'");
    
                logger("Connection values:");
                foreach (DictionaryEntry de in qMgrProp)
                {
                   logger("  " + de.Key + " = '" + de.Value + "'");
                }
             }
             else
             {
                throw new System.ArgumentException();
             }
          }
    
          /// <summary> Connect, open queue, retrieve all messages, close queue and disconnect.</summary>
          /// <throws>  MQException </throws>
          private void handleIt()
          {
             MQQueueManager qMgr = null;
             MQQueue inQ = null;
             int openOptions = MQC.MQOO_INPUT_AS_Q_DEF + MQC.MQOO_FAIL_IF_QUIESCING;
    
             try
             {
                qMgr = new MQQueueManager(qManager, qMgrProp);
                logger("MQTest72 successfully connected to " + qManager);
    
                inQ = qMgr.AccessQueue(inputQName, openOptions);
                logger("MQTest72 successfully opened " + inputQName);
    
                retrieveAll(inQ);
             }
             catch (MQException mqex)
             {
                logger("MQTest72 CC=" + mqex.CompletionCode + " : RC=" + mqex.ReasonCode);
             }
             catch (System.IO.IOException ioex)
             {
                logger("MQTest72 ioex=" + ioex);
             }
             finally
             {
                try
                {
                    if (inQ != null)
                    {
                        inQ.Close();
                        logger("MQTest72 closed: " + inputQName);
                    }
                }
                catch (MQException mqex)
                {
                    logger("MQTest72 CC=" + mqex.CompletionCode + " : RC=" + mqex.ReasonCode);
                }
    
                try
                {
                    if (qMgr != null)
                    {
                        qMgr.Disconnect();
                        logger("MQTest72 disconnected from " + qManager);
                    }
                }
                catch (MQException mqex)
                {
                    logger("MQTest72 CC=" + mqex.CompletionCode + " : RC=" + mqex.ReasonCode);
                }
             }
          }
    
          /// <summary> Retrieve all messages from a queue or until a 'QUIT' message is received.</summary>
          /// <param name="inQ">
          /// </param>
          private void retrieveAll(MQQueue inQ)
          {
             bool flag = true;
             MQGetMessageOptions gmo = new MQGetMessageOptions();
             gmo.Options |= MQC.MQGMO_NO_WAIT | MQC.MQGMO_FAIL_IF_QUIESCING;
             MQMessage msg = null;
    
             while (flag)
             {
                try
                {
                   msg = new MQMessage();
                   inQ.Get(msg, gmo);
                   if (msg.Feedback == MQC.MQFB_QUIT)
                   {
                      flag = false;
                      logger("received quit message - exiting loop");
                   }
                   else
                      logger("Message Data: " + msg.ReadString(msg.MessageLength));
                }
                catch (MQException mqex)
                {
                   logger("CC=" + mqex.CompletionCode + " : RC=" + mqex.ReasonCode);
                   if (mqex.Reason == MQC.MQRC_NO_MSG_AVAILABLE)
                   {
                      // no meesage - life is good
                      flag = false;
                      logger("no more meesages - exiting loop");
                   }
                   else
                   {
                      flag = false;  // severe error - time to exit
                   }
                }
                catch (System.IO.IOException ioex)
                {
                   logger("ioex=" + ioex);
                }
             }
          }
    
          /// <summary> Output the log message to stdio.</summary>
          /// <param name="data">
          /// </param>
          private void logger(String data)
          {
             DateTime myDateTime = DateTime.Now;
             System.Console.Out.WriteLine(myDateTime.ToString("yyyy/MM/dd HH:mm:ss.fff") + " " + this.GetType().Name + ": " + data);
          }
    
          /// <summary> main line</summary>
          /// <param name="args">
          /// </param>
          //        [STAThread]
          public static void Main(System.String[] args)
          {
             MQTest72 mqt = new MQTest72();
    
             try
             {
                mqt.init(args);
                mqt.handleIt();
             }
             catch (System.ArgumentException e)
             {
                System.Console.Out.WriteLine("Usage: MQTest72 -h host -p port -c channel -m QueueManagerName -q QueueName [-u userID] [-x passwd]");
                System.Environment.Exit(1);
             }
             catch (MQException e)
             {
                System.Console.Out.WriteLine(e);
                System.Environment.Exit(1);
             }
    
             System.Environment.Exit(0);
          }
       }
    }
