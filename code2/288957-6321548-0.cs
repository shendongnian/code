		/// <summary>
		/// HiddenForm can be used to marshal calls to the UI thread but is not visible
		/// </summary>
		public class HiddenForm : Form
		{
		  public HiddenForm()
		  {
		   //Making a dummy call to the Handle property will force the native 
		   //window handle to be created which is the minimum requirement for 
		   //InvokeRequired to work.
		   IntPtr hWnd = Handle;
		  }
		}
		
		/// <summary>
		/// AddInService will be exposed through the Object property of the AddIn but does NOT derive 
		/// from StandardOleMarshalObject but instead uses a <see cref="HiddenForm"/> to marshal calls
		/// from an arbitrary RPC thread to the UI thread.
		/// </summary>
		public class AddInService : IAddInService
		{
		  private readonly Form _invokeForm;
		
		  public AddInService()
		  {
		   //create an instance of the HiddenForm which allows to marshal COM
		   //calls to the UI thread.
		   _invokeForm = new HiddenForm();
		  }
		
		  public void HelloOutOfProc()
		  {
		   if(_invokeForm.InvokeRequired)
		   {
		     _invokeForm.Invoke(
		      new Action<object>(o => HelloOutOfProc()), new object()); //not really elegant yet but Action<> was the only "out of the box" solution that I could find
		   }
		   else
		   {
		     MessageBox.Show("HelloOutOfProc on thread id " + Thread.CurrentThread.ManagedThreadId);
		   }
		  }
		}
		
		/// <summary>
		/// AddIn Class which DOES derive from StandardOleMarshalObject so it's executed on the UI thread
		/// </summary>
		public class Connect : StandardOleMarshalObject, IDTExtensibility2
		{
		  private IAddInService _service;
		
		  public void OnConnection(object application, ext_ConnectMode connectMode,
		               object addInInst, ref Array custom)
		  {
		   //create service object that will be exposed to out-of-proc processes
		   _service = new AddInService();
		
		   //expose AddInService through the COMAddIn.Object property
		   ((COMAddIn)addInInst).Object = _service;
		  }
		}
