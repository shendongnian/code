     public class MonitorCallbackFactory{
         public MonitorCallback CreateCallback(){
             //  create the callback instance
             var callback = new MonitorCallback();
             // subscribe the events to the EventHandler.  
             callback.ApplyAccepted += OnApplyAccepted;
             callback.ApplyRejected += OnApplyRejected;
             return callback;
         } 
          
         protected virtual void OnApplyAccepted(object sender, ApplyEventArgs e){
               // the sender is always the type of object that raises the event, so
               // if you need it strongly typed you can do:
               var callback = (MonitorCallback)sender;
               // then write your code for what happens when
               // the ApplyAccepted event is raised here  
         }
         protected virtual void OnApplyRejected(object sender, ApplyEventArgs e){
               // write your code for what happens when
               // the ApplyRejected event is raised here  
         }
     }
