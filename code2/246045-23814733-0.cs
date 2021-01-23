    public class PeriodicTask
    {
        public static Task Run(Action action, TimeSpan period, CancellationToken cancellationToken)
        {
            return Task.Run(async () =>
            {
                while(!cancellationToken.IsCancellationRequested)
                {
                    await Task.Delay(period, cancellationToken);
                    await Task.Run(action, cancellationToken);
                }
             }, cancellationToken);
         }
    }
