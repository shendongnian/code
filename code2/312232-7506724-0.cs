    public class FooDataRepository 
    {
         bool fooCompleted = false;
         bool barCompleted = false;
         int barsSaved = 0;
         int barCount = 0;
         private MyServiceReferenceClient Client { get; set; }
         public void FooClass()
         {
             Client = new MyServiceReferenceClient();
             Client.SaveFooCompleted += Client_SaveFooCompleted;
             Client.SaveBarCompleted += Client_SaveBarCompleted;
         }
    
         private void Client_SaveFooCompleted(Object sender, EventArgs e) 
         {
           fooCompleted = true;
           if (barCompleted)
           {
             SaveCompleted();
           }
         }
         private void Client_SaveBarCompleted(Object sender, EventArgs e) 
         {
           Interlocked.Increment(barsSaved);
           barCompleted = barsSaved == barCount;
           if (fooCompleted)
           {
             SaveCompleted();
           }
         }
         
         private void SaveCompleted()
         {
           //Do whatever you want to do when foo and all bars have been saved
         }
         public void SaveFoo(Foo foo)
         {
            fooCompleted = barCompleted = false;
            barCount = foo.Bars.Count;
            barsSaved = 0;
            Client.SaveFooAsync(foo);
            foreach (var bar in foo.Bars)
                Client.SaveBarAsync(bar);
         }
     } 
