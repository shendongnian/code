    public static void Logger_test() {
     //arrange     
     string fileName = "InventoryPassword1234.log";
     TextWriterTraceListener myListener = new TextWriterTraceListener(fileName, "myListener");
     Trace.Listeners.Add(myListener);
     //act
     Logger.Info("Hello World", "UnitTestProject1");
     //assert
     Trace.Flush();
     Trace.Listeners.Remove("myListener");
     myListener.Dispose();
     Assert.IsTrue(File.Exists(fileName));
     //cleanup
     File.Delete(fileName);
    }
