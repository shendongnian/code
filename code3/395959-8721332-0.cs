    //1. change how the thread is started
    t.Start("y");                               // running WriteY()
     
    //2.change how the thread is started
    static void WriteY(object data)
      {
        //3. use the data parameter
        for (int i = 0; i &lt; 1000; i++) Console.Write ((string) data);
      }
    }
