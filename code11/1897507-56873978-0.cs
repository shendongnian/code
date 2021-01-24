    using System; 
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Linq;
    using System.ServiceProcess;
    using System.Text;
    using System.Threading.Tasks;
    namespace WindowsService1
    {
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }
        private System.Timers.Timer m_mainTimer;
        private bool m_timerTaskSuccess;
        protected override void OnStart(string[] args)
        {
            try
            {
                //
                // Create and start a timer.
                //
                m_mainTimer = new System.Timers.Timer();
                m_mainTimer.Interval = 60000;   // every one min
                m_mainTimer.Elapsed += m_mainTimer_Elapsed;
                m_mainTimer.AutoReset = false;  // makes it fire only once
                m_mainTimer.Start(); // Start
                m_timerTaskSuccess = false;
            }
            catch (Exception ex)
            {
                // omitted
            }
        }
        protected override void OnStop()
        {
            try
            {
                // Service stopped. Also stop the timer.
                m_mainTimer.Stop();
                m_mainTimer.Dispose();
                m_mainTimer = null;
            }
            catch (Exception ex)
            {
                // omitted
            }
        }
        void m_mainTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                // do some work
                m_timerTaskSuccess = true;
            }
            catch (Exception ex)
            {
                m_timerTaskSuccess = false;
            }
            finally
            {
                if (m_timerTaskSuccess)
                {
                    m_mainTimer.Start();
                }
            }
        }        
    }
}
