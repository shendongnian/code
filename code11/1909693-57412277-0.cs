    public static void CreateQueue(NamespaceManager nameSpaceManager, string queueName)
            {
                if (!nameSpaceManager.QueueExists(queueName))
                {
                    var qd = new QueueDescription(queueName)
                    {
                        MaxSizeInMegabytes = 5120,
                        DefaultMessageTimeToLive = new TimeSpan(0, 1, 0)
                        //IsAnonymousAccessible = true
                    };
    
                    nameSpaceManager.CreateQueue(qd);
                }
            }
