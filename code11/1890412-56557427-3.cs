    public class MyClass : MonoBehaviour
    {
         void Start()
         {
             CountdownTimer.RaiseReady += CountdownTimer_RaiseReady;
         }
         private void CountdownTimer_RaiseReady()
         {
              Debug.Log("Done");
              // Remove listener though the other class is already clearing it
              CountdownTimer.RaiseReady -= CountdownTimer_RaiseReady;
         }
    }
