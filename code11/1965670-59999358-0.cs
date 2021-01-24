 csharp
using Android.Content;
[BroadcastReceiver]
public class BackgroundBroadcastReceiver : BroadcastReceiver
{
    public override void OnReceive(Context context, Intent intent)
    {
        // Your code here that will be executed periodically
    }
}
Broadcast receiver registration:
 csharp
// context - any of your Android activity
var intentAlarm = new Intent(context, typeof(BackgroundBroadcastReceiver));
var alarmManager = (AlarmManager)context.GetSystemService(Context.AlarmService);
alarmManager.SetRepeating(AlarmType.ElapsedRealtime, // Works even application\phone screen goes off
                          DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(), // When to start (right now here)
                          1000, // Receiving interval. Set your value here in milliseconds.
                          PendingIntent.GetBroadcast(context, 1, intentAlarm, PendingIntentFlags.UpdateCurrent));
