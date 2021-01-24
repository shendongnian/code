     [BroadcastReceiver]
    [IntentFilter(new [] { Intent.ActionBootCompleted }, Priority = (int)IntentFilterPriority.HighPriority)]
    public class BootBroadcastReceiver : BroadcastReceiver
    {
        public async override void OnReceive(Context context, Intent intent)
        {
            context.StartForegroundServiceCompat<AfterBootSyncService>();
        }
    }
