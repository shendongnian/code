            public void ReactiveExtensionsPerformanceComparisons()
        {
            int iterations = 1000000;
            Action<int> a = (i) => { counter++; };
            DelegateSmokeTest(iterations, a);
            ObservableRangeTest(iterations, a);
            SubjectSubscribeTest(iterations, a, NewThreadScheduler.Default, "NewThread");
            SubjectSubscribeTest(iterations, a, CurrentThreadScheduler.Instance, "CurrentThread");
            SubjectSubscribeTest(iterations, a, ImmediateScheduler.Instance, "Immediate");
            SubjectSubscribeTest(iterations, a, DefaultScheduler.Instance, "ThreadPool");
            // doesn't work, as LinqPad has no Dispatcher attched to the Gui thread, maybe there's a workaround; the Instance property on it is obsolete
            //SubjectSubscribeTest(iterations, a, DispatcherScheduler.Current, "ThreadPool");
        }
