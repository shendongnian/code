    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;
    using System.Windows.Interactivity;
    using System.Windows.Threading;
    
    namespace SilverlightApplication14
    {
        public class LongClickButton : Button
        {
            public event EventHandler LongClick;
    
            public static DependencyProperty HowLongProperty = DependencyProperty.Register("HowLong", typeof(double), typeof(LongClickTrigger), new PropertyMetadata(3000.0));
    
            public double HowLong
            {
                get
                {
                    return (double)this.GetValue(HowLongProperty);
                }
                set
                {
                    this.SetValue(HowLongProperty, value);
                }
            }
    
            private DispatcherTimer timer;
    
            public LongClickButton()
            {
                this.timer = new DispatcherTimer();
                this.timer.Tick += new EventHandler(timer_Tick);
            }
    
            private void timer_Tick(object sender, EventArgs e)
            {
                this.timer.Stop();
                // Timer elapsed while button was down, fire long click event.
                if (this.LongClick != null)
                {
                    this.LongClick(this, EventArgs.Empty);
                }
            }
    
            protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
            {
                base.OnMouseLeftButtonDown(e);
                this.timer.Interval = TimeSpan.FromMilliseconds(this.HowLong);
                this.timer.Start();
            }
    
            protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
            {
                base.OnMouseLeftButtonUp(e);
                this.timer.Stop();
            }
        }
    
    }
