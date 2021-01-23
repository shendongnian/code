// this is in the command-line test client
// no changes to your service required.
static void AsyncTest()
{
  var client = new ServiceReference1.AsyncTestClient();
  client.OperationCompleted += new EventHandler<ServiceReference1.OperationCompletedEventArgs>(client_OperationCompleted);
  client.OperationAsync();
  Console.WriteLine("Operation Running");
}
static void client_OperationCompleted(object sender, ServiceReference1.OperationCompletedEventArgs e)
{
  if (e.Error == null)
    Console.WriteLine("Operation Complete.  Result: " + e.Result);
  else
    Console.WriteLine(e.Error.ToString());
}
