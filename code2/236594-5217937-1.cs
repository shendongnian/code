        public CarrierOperations _string;
        public int _int;     
        public CarrierOperations OperationName
        {
            get { return _string; }
            set { _string = value; }
        }
        public int LoadPortID
        {
            get { return _int; }
            set { _int = value; }
        }
        public Node(CarrierOperations _s, int _v)
        {
            _string = _s;
            _int = _v;         
        }           
    }
    public class ThreadLoops
    {
        
        SequenceCollections collection = new SequenceCollections();
        Parameters[] para = new Parameters[3];
        RunTest[] testArray = new RunTest[3];
        public ThreadLoops()
        {
           para = CreateParameters();           
           testArray = CreateTestObject(para);
        }
        public void Execute()
        {
            collection = CreateSequnce();
           Parameters[] param = CreateParameters();
           
            testArray = CreateTestObject(param);
            //Creation Threads and registring for test case completed events for each single test case.
            for (int index = 0 ; index < 3; index++)
            {
                Thread testCaseExecuteThread = new Thread(new ParameterizedThreadStart(ExecuteSingleTest));
                testCaseExecuteThread.Start(testArray[index]);
                Console.WriteLine("Started RunTest ");                
                //Sleep 5 sec before starting next thread.
               
            }
            Thread.Sleep(100);
           // testArray[2].TestParams.NodeValues.SetEkvent();
            
        }
        private SequenceCollections CreateSequnce()
        {
            Node n1 = new Node(CarrierOperations.Load, 3);
            Node n2 = new Node(CarrierOperations.Load,2);
            Node n3 = new Node(CarrierOperations.Load, 1);
            Node n4 = new Node(CarrierOperations.PRJobCreate, 3);
            Node n5 = new Node(CarrierOperations.PRJobCreate, 1);
            Node n6 = new Node(CarrierOperations.PRJobCreate, 2);
            Node n7 = new Node(CarrierOperations.CJCreate, 1);
            Node n8 = new Node(CarrierOperations.CJCreate, 2);
            Node n9 = new Node(CarrierOperations.CJCreate, 3);
            collection.Add(n1);
            collection.Add(n2);
            collection.Add(n3);
            collection.Add(n4);
            collection.Add(n5);
            collection.Add(n6);
            collection.Add(n7);
            collection.Add(n8);
            collection.Add(n9);
            return collection;
        }
        private RunTest[] CreateTestObject(Parameters[] parameter)
        {
            RunTest[] test = new RunTest[3];
            test[0] = new RunTest(parameter[0]);
            
            test[1] = new RunTest(parameter[1]);
            test[2] = new RunTest(parameter[2]);
            //for (int index=0; index <3; index++)
            //{
            //    test[index] = new RunTest(parameter[index]);               
            //}
            return test;
        }
        private Parameters[] CreateParameters()
        {
            Parameters[] p = new Parameters[3];
            p[0] = new Parameters(1, collection);
            p[1] = new Parameters(2, collection);
            p[2] = new Parameters(3, collection);
            return p;
        }
        /// <summary>
        /// The function that executed by every thread runnig singe run test case.
        /// </summary>
        /// <param name="testCase"></param>
        public void ExecuteSingleTest(object testCaseObject)
        {
            RunTest testCase = (testCaseObject as RunTest);
            //Execution of the test case.
            try
            {
                testCase.Exceute(testCase.TestParams);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
        }
        public void SetRest()
        {
            //collection.processcompleted.Set();
            foreach (Parameters t in param)
            {
                t.NodeValues.processcompleted.Set();
            }
        }
        public void ExecuteSingleTest1(object testCaseObject)
        {
            RunTest testCase = (testCaseObject as RunTest);
            //Execution of the test case.
            try
            {
                testCase.RunSimple(testCase.TestParams);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
        }
    }public enum CarrierOperations
    {
        Load,
        PRJobCreate,
        CJCreate
    }
    public class RunTest
    {
        public static CarrierOperations carrieroperation;
        protected System.IO.StreamWriter file;
        public AutoResetEvent loadoperation;
        public AutoResetEvent PRJobCreate;
        public AutoResetEvent CRJobCreate;
        public Parameters TestParams
        {
            get
            {
                return testParams;
            }
            set
            {
                testParams = value;
            }
        }
         protected Parameters testParams;
        public RunTest(Parameters p)
        {
            TestParams = p;
        }
        protected bool isReachedCollEnd;
        public bool  IsReachedCollEnd
        {
            get
            {
                return isReachedCollEnd;
            }
            set
            {
                isReachedCollEnd = value;
            }
        }
        public void SetEvent()
        {
            testParams.NodeValues.SetEkvent();
        }
        public RunTest()
        {
        }
        public void RunSimple(Parameters p)
        {
            SequenceCollections s = p.NodeValues;            
            testParams = p;
            Console.WriteLine("Waiting before for ID : " + p.LoadPorts.ToString());
            s.processcompleted.WaitOne();
            {
                Console.WriteLine("Entered Loop for ID : "+ p.LoadPorts.ToString());
            }
            
        }
        public void Exceute(Parameters p)
        {
            Form1 f = new Form1();
            testParams = p;
            SequenceCollections coll = p.NodeValues;
            int iterator =0;
            int PortID = 1;
            carrieroperation = CarrierOperations.Load;          
            try
            {
                int threadid = Thread.CurrentThread.ManagedThreadId;
                for (iterator = 0; iterator < coll.NodeList.Count; iterator++)
                {
                    lock (this)
                    {
                        coll.processcompleted.Reset();
                        PortID = coll.NodeList[iterator].LoadPortID;
                    }
                    switch (carrieroperation)
                    {
                        case CarrierOperations.Load:
                            Console.WriteLine(threadid + "  : Thread Load port ID " + coll.NodeList[iterator].LoadPortID); 
                            if (PortID == p.LoadPorts)
                            {
                                lock (this)
                                {
                                    Console.WriteLine("Entered Load operation for LP:" + p.LoadPorts.ToString());
                                    Thread.Sleep(5000);
                                    SetNextEnum(coll, iterator);
                                    coll.SetEkvent();
                                }
                            }
                            else
                            {
                                Console.WriteLine(threadid + "  : " + "Enter (Wait) Load operation for LP:" + p.LoadPorts.ToString() + System.DateTime.Now.Second.ToString());
                                if (!coll.processcompleted.WaitOne())
                                {
                                }
                                Console.WriteLine(threadid + "  : " + " Exit (wait) Load operation for LP:" + p.LoadPorts.ToString() + System.DateTime.Now.Second.ToString());
                                //Console.WriteLine(threadid + "    Exited from Wait Load operation for LP:" + p.LoadPorts.ToString());
                            }
                            Thread.Sleep(200);
                            //coll.processcompleted.Set();
                            break;
                        case CarrierOperations.PRJobCreate:
                            Console.WriteLine(threadid + "  : Thread Load port ID " + coll.NodeList[iterator].LoadPortID); 
                            if (PortID == p.LoadPorts)
                            {
                                lock (this)
                                {
                                    Console.WriteLine("Entered PRJobCreate operation for LP:" + p.LoadPorts.ToString());
                                    Thread.Sleep(1000);
                                    SetNextEnum(coll, iterator);
                                    coll.SetEkvent();
                                }
                            }
                            else
                            {
                                Console.WriteLine(threadid + "  : " + "Enter (Wait) Load operation for LP:" + p.LoadPorts.ToString() + System.DateTime.Now.Second.ToString());
                                if (!coll.processcompleted.WaitOne())
                                {
                                }
                                Console.WriteLine(threadid + "  : " + " Exit (wait) Load operation for LP:" + p.LoadPorts.ToString() + System.DateTime.Now.Second.ToString());
                            }
                            Thread.Sleep(200);
                           // coll.processcompleted.Set();
                            break;
                        case CarrierOperations.CJCreate:
                            Console.WriteLine(threadid + "  : Thread Load port ID " + coll.NodeList[iterator].LoadPortID);
                            if (PortID == p.LoadPorts)
                            {
                                lock (this)
                                {
                                    Console.WriteLine("Entered CJCreate operation for LP:" + p.LoadPorts.ToString());
                                    Thread.Sleep(1000);
                                    SetNextEnum(coll, iterator);
                                    coll.SetEkvent();
                                }
                            }
                            else
                            {
                                Console.WriteLine(threadid + "  : " + "Enter (Wait) Load operation for LP:" + p.LoadPorts.ToString() + System.DateTime.Now.Second.ToString());
                                if (!coll.processcompleted.WaitOne())
                                {
                                }
                                Console.WriteLine(threadid + "  : " + " Exit (wait) Load operation for LP:" + p.LoadPorts.ToString() + System.DateTime.Now.Second.ToString());
                            }
                            Thread.Sleep(200);
                            // coll.processcompleted.Set();
                            break;
                    }
                }
                    
            }
            catch (Exception ex)
            {
                Console.WriteLine("From Execute"+ ex.Message.ToString());
            }
        }
        private void SetNextEnum(SequenceCollections coll, int iterator)
        {
            lock (this)
            {
                int nextIterator = iterator + 1;
                if (nextIterator == coll.NodeList.Count)
                {
                    carrieroperation = CarrierOperations.Load;
                }
                else
                {
                    Node n = coll.NodeList[nextIterator];
                    carrieroperation = n.OperationName;
                }
            }
        }                 
    }
