    // Create a delegate to Foo
    FooDelegate fooDelegate = Foo;
    var asyncResults = new List<IAsyncResult>();
    // Start multiple calls to Foo() in parallel. The loop can be adjusted as required (while, for, foreach).
    while (...)
    {
        // Start executing Foo asynchronously with arguments a, b and c.
        // Collect the async results in a list for later
        results.Add(fooDelegate.BeginInvoke(a, b, c, null, null));
    }
    // List to collect the result of each invocation
    var results = new List<double>();
    // Wait for completion of all of the asynchronous invocations
    foreach (var asyncResult in asyncResults)
    {
        if (!asyncResult.CompletedSynchronously)
        {
            asyncResult.AsyncWaitHandle.WaitOne();
        }
        // Collect the result of the invocation (results will appear in the list in the same order that the invocation was begun above.
        results.Add(fooDelegate.EndInvoke(asyncResult));
    }
    // At this point, all of the asynchronous invocations have returned, and the result of each invocation is stored in the results list.
