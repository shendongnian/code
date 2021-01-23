    protected virtual bool TryContinueOnException(DirectoryInfo dir, Exception ex)
    {
        if (!Aborted)
        {
            var e = ContinueOnExceptionEvent;
            if (e != null)
            {
                var ds = e.GetInvocationList();
                foreach (Func<RecentDirectories, DirectoryInfo, Exception, bool> d in ds)
                {
                    if (d(this, dir, ex))
                        return true;
                }
            }
        }
        return false;
    }
