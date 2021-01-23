    static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            static voidMain()
            {
                Application.ThreadException += new ThreadExceptionEventHandler(new ThreadExceptionHandler().ApplicationThreadException);
                Application.Run(new Form1());
            }
            /// <summary>
            /// Handles any thread exceptions
            /// </summary>
            public class ThreadExceptionHandler
            {
                public void ApplicationThreadException(object sender, ThreadExceptionEventArgs e)
                {
                    MessageBox.Show(e.Exception.Message, “An exception occurred:”, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
