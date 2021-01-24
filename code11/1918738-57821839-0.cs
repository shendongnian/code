    td3.ContinueWith
        (tu =>
            {
                MySqlParameter[] param = tu.Result;
            }
        , new CancellationTokenSource().Token
        , TaskContinuationOptions.OnlyOnRanToCompletion
        , TaskScheduler.Default
        );
