        List<int> data = new List<int>();
    
            void SomeMethod(int[] ids)
            {
                foreach (int id in ids)
                {
                    Work w = new Work();
                    w.Data = id;
                    var myThread = new Thread(new ThreadStart(w.DoWork));
                    
                    myThread.Start(id);
                }
            }
    
            
            class Work
            {
                public int Data { get; set; }
    
                public void DoWork()
                {
                    Console.WriteLine("Instance thread . Data={0}", Data);
                }
    
            }
