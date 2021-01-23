    using System;
    using System.Windows.Forms;
    using System.Threading.Tasks;
    namespace Foo {
        partial class Form1: Form {
            private static readonly object mousePressLock = new object();
            private bool mousePressed;
            private Task task;
            private async Task MouseAction(Action action) {
                while (true) {
                    lock (mousePressLock) {
                        if (mousePressed)
                            action();
                        else
                            break;
                    }
                    await Task.Delay(100).ConfigureAwait(false);
                }
            }
            private void PnlTranslate_Paint(object sender, PaintEventArgs e) {
            }
            private void Up_MouseUp(object sender, MouseEventArgs e) {
                lock (mousePressLock) { mousePressed = false; }
                task.Wait();
            }
            private void Up_MouseDown(object sender, MouseEventArgs e) {
                lock (mousePressLock) { mousePressed = true; }
                int cnt = 0;
                task = MouseAction(() => {
                    Console.WriteLine($"mouse up action {++cnt}");
                });
            }
            public Form1() {
                InitializeComponent();
                mousePressed = false;
                task = null;
            }
        }
    }
