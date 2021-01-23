private void StopListening()
{
    Reflection.ReflectionHelper.InvokeMethod(chromeListener, "RemoveAll", new object[] {false});
    Reflection.ReflectionHelper.InvokeMethod(chromeListener, "Dispose", new object[] {true});
    pendingRequestQueue.Clear(); //this is something we use but just in case you have some requests clear them
}
</pre>
