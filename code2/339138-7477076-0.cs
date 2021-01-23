    public class WorkerRole : RoleEntryPoint
    {
        public override void Run()
        {
            var logic = new WorkerAgent();
            logic.Go(false);
        }
        public override bool OnStart()
        {
            // Initialize our Cloud Storage Configuration.
            AzureStorageObject.Initialize(AzureConfigurationLocation.AzureProjectConfiguration);
            return base.OnStart();
        }
    }
    public class WorkerAgent
    {
        private const int _resistance_to_scaling_larger_queues = 9;
        private Dictionary<Type, int> _queueWeights = new Dictionary<Type, int>
                                                           {
                                                               {typeof (Queue1.Processor), 1},
                                                               {typeof (Queue2.Processor), 1},
                                                               {typeof (Queue3.Processor), 1},
                                                               {typeof (Queue4.Processor), 1},
                                                           };
        private readonly TimeSpan _minDelay = TimeSpan.FromMinutes(Convert.ToDouble(RoleEnvironment.GetConfigurationSettingValue("MinDelay")));
        private readonly TimeSpan _maxDelay = TimeSpan.FromMinutes(Convert.ToDouble(RoleEnvironment.GetConfigurationSettingValue("MaxDelay")));
        protected TimeSpan CurrentDelay { get; set; }
        public Func<string> GetSpecificQueueTypeToProcess { get; set; }
        /// <summary>
        /// This is a superset collection of all Queues that this WorkerAgent knows how to process, and the weight of focus it should receive.
        /// </summary>
        public Dictionary<Type, int> QueueWeights
        {
            get
            {
                return _queueWeights;
            }
            set
            {
                _queueWeights = value;
            }
        }
        public static TimeSpan QueueWeightCalibrationDelay
        {
            get { return TimeSpan.FromMinutes(15); }
        }
        protected Dictionary<Type, DateTime> QueueDelays = new Dictionary<Type, DateTime>();
        protected Dictionary<Type, AzureQueueMetaData> QueueMetaData { get; set; }
        public WorkerAgent(Func<string> getSpecificQueueTypeToProcess = null)
        {
            CurrentDelay = _minDelay;
            GetSpecificQueueTypeToProcess = getSpecificQueueTypeToProcess;
        }
        protected IProcessQueues CurrentProcessor { get; set; }
        /// <summary>
        /// Processes queue request(s).
        /// </summary>
        /// <param name="onlyProcessOnce">True to only process one time. False to process infinitely.</param>
        public void Go(bool onlyProcessOnce)
        {
            if (onlyProcessOnce)
            {
                ProcessOnce(false);
            }
            else
            {
                ProcessContinuously();
            }
        }
        public void ProcessContinuously()
        {
            while (true)
            {
                // temporary hack to get this started.
                ProcessOnce(true);
            }
        }
        /// <summary>
        /// Attempts to fetch and process a single queued request.
        /// </summary>
        public void ProcessOnce(bool shouldDelay)
        {
            PopulateQueueMetaData(QueueWeightCalibrationDelay);
            if (shouldDelay)
            {
                Thread.Sleep(CurrentDelay);
            }
            var typesToPickFrom = new List<Type>();
            foreach(var item in QueueWeights)
            {
                for (var i = 0; i < item.Value; i++)
                {
                    typesToPickFrom.Add(item.Key);
                }
            }
            var randomIndex = (new Random()).Next()%typesToPickFrom.Count;
            var typeToTryAndProcess = typesToPickFrom[randomIndex];
            CurrentProcessor = ObjectFactory.GetInstance(typeToTryAndProcess) as IProcessQueues;
            CleanQueueDelays();
            if (CurrentProcessor != null && !QueueDelays.ContainsKey(typeToTryAndProcess))
            {
                var errors = CurrentProcessor.Go();
                var amountToDelay = CurrentProcessor.NumberProcessed == 0 && !errors.Any()
                                   ? _maxDelay // the queue was empty
                                   : _minDelay; // else
                QueueDelays[CurrentProcessor.GetType()] = DateTime.Now + amountToDelay;
            }
            else
            {
                ProcessOnce(true);
            }
        }
        /// <summary>
        /// This method populates/refreshes the QueueMetaData collection.
        /// </summary>
        /// <param name="queueMetaDataCacheLimit">Specifies the length of time to cache the MetaData before refreshing it.</param>
        private void PopulateQueueMetaData(TimeSpan queueMetaDataCacheLimit)
        {
            if (QueueMetaData == null)
            {
                QueueMetaData = new Dictionary<Type, AzureQueueMetaData>();
            }
            var queuesWithoutMetaData = QueueWeights.Keys.Except(QueueMetaData.Keys).ToList();
            var expiredQueueMetaData = QueueMetaData.Where(qmd => qmd.Value.TimeMetaDataWasPopulated < (DateTime.Now - queueMetaDataCacheLimit)).Select(qmd => qmd.Key).ToList();
            var validQueueData = QueueMetaData.Where(x => !expiredQueueMetaData.Contains(x.Key)).ToList();
            var results = new Dictionary<Type, AzureQueueMetaData>();
            foreach (var queueProcessorType in queuesWithoutMetaData)
            {
                if (!results.ContainsKey(queueProcessorType))
                {
                    var queueProcessor = ObjectFactory.GetInstance(queueProcessorType) as IProcessQueues;
                    if (queueProcessor != null)
                    {
                        var queue = new AzureQueue(queueProcessor.PrimaryQueueName);
                        var metaData = queue.GetMetaData();
                        results.Add(queueProcessorType, metaData);
                        QueueWeights[queueProcessorType] = (metaData.ApproximateMessageCount) == 0
                                                      ? 1
                                                      : (int)Math.Log(metaData.ApproximateMessageCount, _resistance_to_scaling_larger_queues) + 1;
                    }
                }
            }
            foreach (var queueProcessorType in expiredQueueMetaData)
            {
                if (!results.ContainsKey(queueProcessorType))
                {
                    var queueProcessor = ObjectFactory.GetInstance(queueProcessorType) as IProcessQueues;
                    if (queueProcessor != null)
                    {
                        var queue = new AzureQueue(queueProcessor.PrimaryQueueName);
                        var metaData = queue.GetMetaData();
                        results.Add(queueProcessorType, metaData);
                    }
                }
            }
            QueueMetaData = results.Union(validQueueData).ToDictionary(data => data.Key, data => data.Value);
        }
        private void CleanQueueDelays()
        {
            QueueDelays = QueueDelays.Except(QueueDelays.Where(x => x.Value < DateTime.Now)).ToDictionary(x => x.Key, x => x.Value);
        }
    }
