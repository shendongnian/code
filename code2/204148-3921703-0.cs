    class MyThread {
        
        int count;
        Thread thrd;
        
        public MyThread(string name) { 
            count = 0; 
            thrd = new Thread(new ThreadStart(this.run)); // here m getting error
            thrd.Name = name; 
            thrd.Start(); 
        } 
        
        // Entry point of thread. 
        void run() { 
            Console.WriteLine(thrd.Name + " starting."); 
            
            do { 
                Thread.Sleep(500); 
                Console.WriteLine("In " + thrd.Name + 
                                  ", count is " + count); 
                count++; 
            } while(count < 10); 
            
            Console.WriteLine(thrd.Name + " terminating."); 
        } 
    }
