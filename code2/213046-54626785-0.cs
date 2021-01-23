    namespace Foo {
        partial class Form1: Form {
            private static readonly object mousePressLock = new object();
            private bool mousePressed;
            private Task task;
            private void Up_MouseUp(object sender, MouseEventArgs e) {
                lock (mousePressLock) { mousePressed = false; }
                task.Wait();
            }
            private void Up_MouseDown(object sender, MouseEventArgs e) {
                lock (mousePressLock) { mousePressed = true; }
                task = Task.Run(async () => {
                    int cnt = 0;
                    while (true) {
                        lock (mousePressLock) {
                            if (mousePressed)
                                Console.WriteLine($"mouse up action {++cnt}");
                            else
                                break;
                        }
                        await Task.Delay(200);
                    }
                });
            }
            public Form1() {
                InitializeComponent();
                mousePressed = false;
                task = null;
            }
        }
    }
