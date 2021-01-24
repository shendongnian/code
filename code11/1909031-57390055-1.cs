    I use this form class: -
    
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace Yournamespace
    {
        public partial class frmProgressBar : Form
        {
            public Action Worker { get; set; }
    
            System.Diagnostics.Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();
    
            public const long MINIMUM_DISPLAY_TIME = 300;    // Minimum time to display the progress bar is 300 milliseconds
    
            public frmProgressBar(Action worker)
            {
                InitializeComponent();
    
                if(worker == null)
                {
                    throw new ArgumentNullException();
                }
    
                Worker = worker;
            }
    
            protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);
    
                Task.Factory.StartNew(Worker).ContinueWith(t => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
            }
    
            protected override void OnClosed(EventArgs e)
            {
                // the code that you want to measure comes here
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
    
                if (elapsedMs < MINIMUM_DISPLAY_TIME) //ensure progress bar is displayed for at least 100 milliseconds, otherwise it just looks like the parent main form glitches.
                {
                    long lDelay = MINIMUM_DISPLAY_TIME - elapsedMs;
    
                    Thread.Sleep((int)lDelay);
                }
            }
        }
    }
    
    The form design looks like this : -
    
    [![enter image description here][1]][1]
    
    
      [1]: https://i.stack.imgur.com/n4XqU.jpg
    
    
    And I call it like this: -
    
                using (Yournamespace.frmProgressBar frm = new Yournamespace.frmProgressBar(Yourprocess))
                {
                    frm.ShowDialog(this);
                }
    
    
    Yourprocess is the code that you want to execute that is causing the delay.
    
    The main problem with this implementation is Yourprocess cannot return a value or take parameters. I am sure the code can be changed to accomodate this but I did not have time so I use globals to pass in data and to see results(shame on me).
    
    This is not my code, although I have modified it, came from a you tube video - Wait Form Dialog.
