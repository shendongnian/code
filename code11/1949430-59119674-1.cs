    var obs = Using(
        () => new FileStream("file.txt", FileMode.Open),
        (fs) => new StreamReader(fs),
        (fs, sr) => Observable.Create<string>(o =>
            TaskPoolScheduler.Default.ScheduleAsync(async (sch, ct) =>
            {
                while (!ct.IsCancellationRequested)
                {
                    var s = await sr.ReadLineAsync().ConfigureAwait(false);
                    if (s is null) break;
                    o.OnNext(s);
                }
                o.OnCompleted();
            })));
