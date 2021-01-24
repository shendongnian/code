    public class DisposeFormDemo
    {
        private class MyForm : Form
        {
            public MyForm() => Text = $"Main thread id = {Thread.CurrentThread.ManagedThreadId}";
        }
        public delegate void MyDelegate(Form form);
        public static void Main()
        {
            var form = new MyForm();
            Task.Run(async () => await Task.Delay(3000).ContinueWith(_ =>
            {
                MessageBox.Show($"Task thread id = {Thread.CurrentThread.ManagedThreadId}");
                var myDelegate = new MyDelegate(f =>
                {
                    MessageBox.Show($"Current thread id = {Thread.CurrentThread.ManagedThreadId}");
                    f.Dispose();
                });
                form.Invoke(myDelegate, form);
            }));
            form.ShowDialog();
        }
    }
