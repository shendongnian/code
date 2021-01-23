	public partial class Form1 : Form
	{
		AsyncDelegate ad;
		TimeZ t = new TimeZ();
		
		// Our synchronization context
		SynchronizationContext syncContext;
		
		public Form1()
		{
			InitializeComponent();
			
			// Initialize the synchronization context field
			syncContext = SynchronizationContext.Current;
		}
		private void btn_async_Click(object sender, EventArgs e)
		{
			ad = new AsyncDelegate(t.GetTime);
			AsyncCallback acb = new AsyncCallback(CB);
			if (chk_sec.Checked)
			{
				ad.BeginInvoke(true, acb, null);
			}
			else
			{
				ad.BeginInvoke(false, acb, null);
			}
		}
		public void CB(IAsyncResult ar)
		{
			// this will be executed in another thread
			t.Tim = ar.ToString();
			ad.EndInvoke(ar);
			syncContext.Post(null, delegate(object state)
			{
				// This will be executed again in form thread
				lbl_time.Text = t.Tim;
			});
		}
