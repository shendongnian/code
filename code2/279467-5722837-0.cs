    class Client
    {
         DatabaseClass DC = new DatabaseClass();
         DC.PerformMethod(); //Blissfully unaware of the methods inner workings.
     }
    class DatabaseClass
    {
        public void PerformMethod()
        {
            //Encapsulate DB Logic here.  If you need to change it, you can just change it here and the client needs to know nothing of it
         }
     }
