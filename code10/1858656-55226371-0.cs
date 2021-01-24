        //
        // Summary:
        //     Create a new host to process events from an Event Hub.
        //     This overload of the constructor allows maximum flexibility. This one allows
        //     the caller to specify the name of the processor host as well. The overload also
        //     allows the caller to provide their own lease and checkpoint managers to replace
        //     the built-in ones based on Azure Storage.
        //
        // Parameters:
        //   hostName:
        //     Name of the processor host. MUST BE UNIQUE. Strongly recommend including a Guid
        //     to ensure uniqueness.
        //
        //   eventHubPath:
        //     The name of the EventHub.
        //
        //   consumerGroupName:
        //     The name of the consumer group within the Event Hub.
        //
        //   eventHubConnectionString:
        //     Connection string for the Event Hub to receive from.
        //
        //   checkpointManager:
        //     Object implementing ICheckpointManager which handles partition checkpointing.
        //
        //   leaseManager:
        //     Object implementing ILeaseManager which handles leases for partitions.
        public EventProcessorHost(string hostName, string eventHubPath, string consumerGroupName, string eventHubConnectionString, ICheckpointManager checkpointManager, ILeaseManager leaseManager);
