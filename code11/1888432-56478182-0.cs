     class Foo
     {
       bool spin;
       void Worker()
       {      
           Print("start");
           ///Do job
           Print("end")
          
          spin=false;
       }
       void mainMethod()
       {    
            spin = true;
            ThreadPool.QueueUserWorkItem(new WaitCallback(Worker));
            while(spin)
            {
                 Thread.Sleep(500);
                 Application.DoEvents(); 
            }
       }
     }
