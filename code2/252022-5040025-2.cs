    using System.Diagnostics;
    using System.Drawing;
    using System.Windows.Forms;
    
    public class Program {
        public static void Main() {
            var form = new Form {ClientSize = new Size(400, 300)};
            var button = new Button {Location = new Point(0, 0), Text = "Start", Size = new Size(400, 22)};
            var listBox = new ListBox {Location = new Point(0, 22), Size = new Size(400, 278)};
            form.Controls.AddRange(new Control[] {button, listBox});
    
            button.Click += (sender, eventArgs) => {
                var info = new ProcessStartInfo("test.bat") {UseShellExecute = false, RedirectStandardOutput = true};
                var proc = new Process {StartInfo = info, EnableRaisingEvents = true};
                proc.OutputDataReceived += (obj, args) => {
                    if (args.Data != null) {
                        listBox.Items.Add(args.Data);
                    }
                };
                proc.Start();
                proc.BeginOutputReadLine();
            };
    
            form.ShowDialog();
        }
    }
