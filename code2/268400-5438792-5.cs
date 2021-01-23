     var keysIO =   Observable.FromEvent<KeyDownEventHandler, RoutedEventArgs>(
                                        h => new KeyDownEventHandler(h),
                                        h => btn.KeyDown += h,
                                        h => btn.KeyDown -= h));
     var searchResults = keysIO.Throttle(TimeSpan.FromSeconds(0.750),Scheduler.Dispatcher);
     searchResults.Subscribe(sr => {  lb.Clear(); lb.AddRange(sr); });
