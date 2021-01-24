    public async Task DoSomething(int x)
            {
                try
                {
                    switch (x)
                    {
                        case 43:
                            var foo = new Foo();
                            break;
                        case 42:
                            Debug.WriteLine(x);
                            break;
                        case 44:
                            break;
                        default:
                            throw new MyException("aaarghh..");
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
    
            private async void button1_Click(object sender, EventArgs e)
            {
                await DoSomething(42);
            }
    
            public class MyException : Exception
            {
                public MyException(string message): base(message)
                {
                    if (message != null)
                        Debug.WriteLine(message);
                }
    
                public MyException() : base()
                {
                }
    
                public MyException(string message, Exception innerException) : base(message, innerException)
                {
                }
            }
