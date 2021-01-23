            AsynchronousVisibleButtonDelegate asyncDeleg = new AsynchronousVisibleButtonDelegate(AsynchronousVisibleButton);
            AsyncCallback callback = new AsyncCallback(p =>
                                                           {
                                                               var anotherState =
                                                                   p.AsyncState as AsynchronousVisibleButtonDelegate;
                                                               b.Visible = anotherState.EndInvoke(p);
                                                           });
            asyncDeleg.BeginInvoke(b, callback, asyncDeleg);
