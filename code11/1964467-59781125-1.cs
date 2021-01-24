    public static void DelayMe(Action myVoidMethod, TimeSpan delayTime)
    {
        Func<bool> f = () => { myVoidMethod.Invoke(); return false; };
        System.Threading.Timer t = default;
        t = new System.Threading.Timer(_ =>
        {
            if (!f())
            {
                t.Dispose();
            }
        }, null, default(TimeSpan), delayTime);
    }
