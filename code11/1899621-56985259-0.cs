csharp
		private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Controls.Calendar calendar1;
        private void Form1_Load(object sender, EventArgs e)
        {
            // Add reference to PresentationFramework
            calendar1 = new System.Windows.Controls.Calendar();
            // Test Background
            // Add reference to PresentationCore
            // Add reference to WindowsBase
            System.Windows.Media.LinearGradientBrush linearGradientBrush = new System.Windows.Media.LinearGradientBrush(System.Windows.Media.Colors.Cyan, System.Windows.Media.Colors.Blue, new System.Windows.Point(0, 0), new System.Windows.Point(0, 1));
            calendar1.Background = linearGradientBrush;
            // Container for Calendar
            System.Windows.Controls.Canvas canvas = new System.Windows.Controls.Canvas();
            System.Windows.Controls.Viewbox viewbox1 = new System.Windows.Controls.Viewbox();
            viewbox1.StretchDirection = System.Windows.Controls.StretchDirection.Both;
            viewbox1.Stretch = System.Windows.Media.Stretch.Fill;
            viewbox1.MaxWidth = 260;
            viewbox1.MaxHeight = 260;
            viewbox1.Child = calendar1;
            canvas.Children.Add(viewbox1);
            // Test Event
            calendar1.SelectedDatesChanged += calendar1_SelectedDatesChanged;
            textBox1 = new System.Windows.Forms.TextBox();
            textBox1.Location = new System.Drawing.Point(10, 280);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(149, 20);
            Controls.Add(textBox1);
            // Test new Culture
            // using System.Globalization;
            CultureInfo cultureinfo = (CultureInfo.CurrentCulture.Clone() as CultureInfo);
            cultureinfo.DateTimeFormat.YearMonthPattern = @"yyyy - MMMM";
            //cultureinfo.DateTimeFormat.YearMonthPattern = @"MMMM";
            System.Threading.Thread.CurrentThread.CurrentCulture = cultureinfo;
            // Host for controls
            // Add reference to WindowsFormsIntegration
            // using System.Windows.Forms.Integration;
            var elementHost = new ElementHost();
            elementHost.Child = canvas;
            Controls.Add(elementHost);
            elementHost.Location = new System.Drawing.Point(10, 10);
            elementHost.Size = new System.Drawing.Size(300, 300);
            ClientSize = new System.Drawing.Size(280, 340);
            CenterToScreen();
        }
        private void calendar1_SelectedDatesChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            textBox1.Text = calendar1.SelectedDate.ToString();
        }
  [1]: https://docs.microsoft.com/dotnet/api/system.windows.controls.calendar?view=netframework-4.8
  [2]: https://i.stack.imgur.com/npz3x.jpg
