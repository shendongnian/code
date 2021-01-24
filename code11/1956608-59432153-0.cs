public class {
   int Result { get; set; }
   
   void TimerFunc(a, b) { Result = <some calculation>; }
   Main() {
      StartTimer();
      while(true) { CheckResult(Result); }
   }
}
If you are instead wanting to run some logic (such as checking a database) after the other event runs, you need to make both things a part of what's set up for the timer:
async void SubscribeToConfigAsync(...){
   await userFunc(...);
   await runDatabaseUpdates(...);
}
If instead you want to stop and restart the `Timer` based on some config value changing, you'll want to keep a reference to the `Timer` instance.
Main() {
   var oldConfigValues = <empty object>;
   Timer t = null;
   while(true){
      var newConfigValues = GetDbConfigValues();
      if(newConfigValues != oldConfigValues){
         if(t != null){ <stop timer> }
         t = InitializeTimer(newConfigValues);
         oldConfigValues = newConfigValues;
      }
   }
}
