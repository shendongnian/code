    namespace WindowsFormsApplication1
    {
        using System;
        using System.Windows.Forms;
        public partial class Form1 : Form
        {
            /// <summary>
            /// The default constructor.
            /// I used the designer, so the InitializeComponent method contains the timer and combobox initialization.
            /// </summary>
            public Form1()
            {
                InitializeComponent();
            }
            /// <summary>
            /// Occurs when the combo box selection changes.
            /// </summary>
            /// <param name="sender">The sender object, i.e., the combobox</param>
            /// <param name="e">The event arguments.</param>
            private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (autoRefresh.Enabled == true)
                {
                    autoRefresh.Enabled = false;
                }
                // so I can easily change the time scale when debugging, I'm using a multiplier
                const int multiplier = 10000;
                // notice I'm using SelectedItem because the event triggered was index changed, not text changed
                var selectedInterval = comboBox1.SelectedItem.ToString();
                // if a valid entry wasn't selected, then we'll disable the timer
                var enabled = true;
                switch (selectedInterval)
                {
                    case "4 hours":
                        autoRefresh.Interval = 1440 * multiplier;
                        break;
                    case "2 hours":
                        autoRefresh.Interval = 720 * multiplier;
                        break;
                    case "1 hour":
                        autoRefresh.Interval = 360 * multiplier;
                        break;
                    case "15 minutes":
                        autoRefresh.Interval = 90 * multiplier;
                        break;
                    case "10 seconds":
                        autoRefresh.Interval = 1 * multiplier;
                        break;
                    default:
                        // we didn't choose a valid entry, or picked blank line
                        enabled = false;
                        break;
                }
                autoRefresh.Enabled = enabled;
            }
            /// <summary>
            /// Occurs every time the timer reaches its interval
            /// </summary>
            /// <param name="sender">The sender object, i.e., the timer.</param>
            /// <param name="e">The event arguments.</param>
            private void AutoRefresh_Tick(object sender, EventArgs e)
            {
                // to ensure the next timer triggers at the desired interval
                // stop the timer while doing the operations in this method (they could be lengthy)
                // and then restart the timer before exiting
                autoRefresh.Enabled = false;
                // give a visual indicator of the timer ticking.
                // Here is where you would do your DB operation.
                MessageBox.Show(string.Format("Hello! time={0}:{1}", DateTime.Now.ToLongTimeString(), DateTime.Now.Millisecond));
                autoRefresh.Enabled = true;
            }
        }
    }
