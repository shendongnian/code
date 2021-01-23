            startMouseDown
                .SelectMany(down =>
                    createUrlObservable()
                        .SelectMany(url => createRequestObservable(url)
                            .TakeUntil(stopMouseDown)
                            .Select(r => r.GetResponseStream())
                            .Do(s =>
                                {
                                    using (var sr = new StreamReader(s))
                                    {
                                        Trace.WriteLine(sr.ReadLine());
                                        Trace.Flush();
                                    }
                                })
                            .Do(r => this._successed++)
                            .HandleError(e => this._failed++))
                            .ObserveOnDispatcher()
                            .Do(_ => this.RefresLabels(),
                                e => { },
                                () => this.RefresLabels())
                            )
                .Subscribe();
