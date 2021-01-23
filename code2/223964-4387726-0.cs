        public IList<Entry> Get(ID key)
        {
            ConcurrentBag<Entry> entries = new ConcurrentBag<Entry>();
            ConcurrentDictionary<Contact, bool> done = new ConcurrentDictionary<Contact, bool>();
            List<Thread> threads = new List<Thread>();
            foreach (Contact c in this.p_Contacts)
            {
                Thread t;
                ThreadStart ts = delegate()
                {
                    try
                    {
                        FetchMessage fm = new FetchMessage(this, c, key);
                        fm.Send();
                        int ticks = 0;
                        // Wait until we receive data, or timeout.
                        while (!fm.Received && ticks < 1500)
                        {
                            Thread.Sleep(100);
                            ticks += 100;
                        }
                        if (fm.Received)
                        {
                            foreach (Entry e in fm.Values)
                            {
                                Console.WriteLine("Added " + e.Value + " to the entries.");
                                entries.Add(e);
                            }
                            if (entries.Count == 0)
                                Console.WriteLine("There were no entries to add.");
                        }
                        else
                            Console.WriteLine("The node did not return in time.");
                        Thread.MemoryBarrier();
                        done[c] = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                };
                t = new Thread(ts);
                done[c] = false;
                t.IsBackground = true;
                t.Start();
            }
            while (true)
            {
                bool stopped = true;
                foreach (Contact c in this.p_Contacts)
                {
                    if (!done[c])
                        stopped = false;
                }
                if (stopped)
                    break;
                Thread.Sleep(100);
            }
            return new List<Entry>(entries.ToArray());
        }
