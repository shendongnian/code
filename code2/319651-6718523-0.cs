	namespace WindowsFormsApplication1
	{
		public partial class Form1 : Form
		{
			private Task _TaskSqlData;
			private CancellationTokenSource cTokenSourceSql;
			WorkDoingClass _work;
			public Form1()
			{
				InitializeComponent();
				listBox1.DataSource = AllMessages.Instance.AllMessagesBindingList;
				listBox1.DisplayMember = "MessageSummary";
				_work = new WorkDoingClass(SynchronizationContext.Current);
			}
			private void button1_Click(object sender, EventArgs e)
			{
				cTokenSourceSql = new CancellationTokenSource();
				var tokenSqlData = cTokenSourceSql.Token;
				if (this._TaskSqlData != null)
				{
					if (this._TaskSqlData.Status == TaskStatus.Running)
						this.cTokenSourceSql.Cancel();
					this._TaskSqlData.Dispose();
					this._TaskSqlData = null;
				}
				_TaskSqlData = Task.Factory.StartNew(()
								=> StartDoingWork(this, tokenSqlData, null), tokenSqlData);
			}
			public void StartDoingWork(object sender, CancellationToken ct, EventArgs e)
			{
				if (ct.IsCancellationRequested)
					ct.ThrowIfCancellationRequested();
				_work.DoSomeOtherWork();
			}
		}
		public class Message
		{
			private string messageSummary;
			public Message() { }
			public string MessageSummary
			{
				set { messageSummary = value; }
				get { return messageSummary; }
			}
		}
		public class WorkDoingClass
		{
			private SynchronizationContext _syncContext;
			public WorkDoingClass() { }
			public WorkDoingClass(SynchronizationContext _syncContext)
			{
				// TODO: Complete member initialization
				this._syncContext = _syncContext;
			}
			public void DoSomeWork()
	        {
	            //some routines
	            Message messageObj = new Message();
	            messageObj.MessageSummary = "DoSOmrWork Finished";
	        }
			public void DoSomeOtherWork()
	        {
				_syncContext.Send(DoWork, null);
	        }
			private static void DoWork(object arg)
			{
				//some routines
				Message messageObj = new Message();
				messageObj.MessageSummary = "DoSomeOtherWork Finished";
				AllMessages.Instance.AllMessagesBindingList.Add(messageObj);
			}
		}
		public sealed class AllMessages
	    {
	        private static readonly AllMessages _instance = new AllMessages();
	        private BindingList<Message> _allMessagesBL;
	        public AllMessages() { _allMessagesBL = new BindingList<Message>(); }
	        public static AllMessages Instance
	        {
	            get { return _instance; }
	        }
	        public BindingList<Message> AllMessagesBindingList
	        {
				get { return _allMessagesBL; }
	        }
	    }
	}
