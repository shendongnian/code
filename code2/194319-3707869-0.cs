    public class Example
    {
        public static void Main(string[] argv)
        {
            //setup
            DownloadQueue personQueue = new DownloadQueue();
            personQueue.JobTriggered += OnHandlePerson;
            personQueue.ThreadLimit = 10; //can be changed at any time and will be adjusted when a job completed (or a new one is enqueued)
            // enqueue as many persons as you like
            personQueue.Enqueue(new Person());
            Console.ReadLine();
        }
        public static void OnHandlePerson(object source, PersonEventArgs e)
        {
            //download persno here.
        }
    }
    public class DownloadQueue
    {
        Queue<Person> _queue = new Queue<Person>();
        int _runningThreads = 0;
        public int ThreadLimit { get; set; }
        /// <summary>
        /// Enqueue a new user.
        /// </summary>
        /// <param name="person"></param>
        public void Enqueue(Person person)
        {
            lock (_queue)
            {
                _queue.Enqueue(person);
                if (_runningThreads < ThreadLimit)
                    ThreadPool.QueueUserWorkItem(DownloadUser);
            }
        }
        /// <summary>
        /// Running using a ThreadPool thread.
        /// </summary>
        /// <param name="state"></param>
        private void DownloadUser(object state)
        {
            lock (_queue)
                ++_runningThreads;
            while (true)
            {
                Person person;
                lock (_queue)
                {
                    if (_queue.Count == 0)
                    {
                        --_runningThreads;
                        return; // nothing more in the queue. Lets exit
                    }
                    person = _queue.Dequeue();
                }
                JobTriggered(this, new PersonEventArgs(person));
            }
        }
        public event EventHandler<PersonEventArgs> JobTriggered = delegate { };
    }
    
    public class PersonEventArgs : EventArgs
    {
        Person _person;
        public PersonEventArgs(Person person)
        {
            _person = person;
        }
        public Person Person { get { return _person; } }
    }
    public class Person
    {
        public Person(string fName, string lName)
        {
            this.firstName = fName;
            this.lastName = lName;
        }
        public string firstName;
        public string lastName;
    }
