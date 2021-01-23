private void StopListening()
{
    Reflection.ReflectionHelper.InvokeMethod(httpListener, "RemoveAll", new object[] {false});
    httpListener.Close();
    pendingRequestQueue.Clear(); //this is something we use but just in case you have some requests clear them
}
</pre>
