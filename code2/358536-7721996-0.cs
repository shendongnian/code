     public partial class _Default : System.Web.UI.Page
        {
    
    
            protected void Page_Load(object sender, EventArgs e)
            {
                
    
                List<Timerx> timers = new List<Timerx>();
                foreach (int dataValue in Enumerable.Range(0, 10))
                {
                    timers.Add(new Timerx() { TimerName = "Timer"+dataValue });
                }
            }
        }
        public class Timerx : Timer
        {
            public string TimerName { get; set; }
        }
