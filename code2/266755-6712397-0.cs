    public class Form1 : Form
    {
        private void Button1_Click(object sender, EventArgs e)
        {
            AsyncHelper.Invoke<bool>(PerformOperation);
        }
    
        private IEnumerable<Task> PerformOperation(TaskCompletionSource<bool> tcs)
        {
            Button1.Enabled = false;
            for (int i = 0; i < 10; i++)
            {
                textBox1.Text = "Before await " + Thread.CurrentThread.ManagedThreadId.ToString();
                yield return SomeOperationAsync(); // Await
                textBox1.Text = "After await " + Thread.CurrentThread.ManagedThreadId.ToString();
            }
            Button2.Enabled = true;
            tcs.SetResult(true); // Return true
        }
    
        private Task SomeOperationAsync()
        {
            // Simulate an asynchronous operation.
            return Task.Factory.StartNew(() => Thread.Sleep(1000));
        }
    }
