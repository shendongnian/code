            public void ReactiveExtensionsPerformanceComparisons()
        {
            int iterations = 1000000;
            Action<int> a = (i) => { counter++; };
            DelegateSmokeTest(iterations, a);
            ObservableRangeTest(iterations, a);
            SubjectSubscribeTest(iterations, a, NewThreadScheduler.Default, "NewThread");
            SubjectSubscribeTest(iterations, a, Scheduler.CurrentThread, "CurrentThread");
            SubjectSubscribeTest(iterations, a, Scheduler.Immediate, "Immediate");
            SubjectSubscribeTest(iterations, a, Scheduler.Default, "ThreadPool");
            // doesn't work, as LinqPad has no Dispatcher attched to the Gui thread, maybe there's a workaround
            //SubjectSubscribeTest(iterations, a, DispatcherScheduler.Current, "ThreadPool");
        }
