    for (int i=11; i != 335 ; i++)
    {
     
         st.Start();
         Process(i);
         st.Stop();    
         Console.WriteLine(st.ElapsedMilliseconds.ToString());
            //This time is more than the time in which thread sleeps
         st.Reset();                       
         Thread.Sleep(70);   }
