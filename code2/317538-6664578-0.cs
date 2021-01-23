    // Implementation of the below class in your MDI Parent
    private void openToolStripMenuItem_Click(object sender, EventArgs e) {
    			if (SingletonForm.Exists) {
    				return;
    			} else {
    				m_openToolStripMenuItem.Enabled = false;
    
    				SingletonForm form = new SingletonForm();
    				form.FormClosed += new FormClosedEventHandler(
    					delegate(object _sender, FormClosedEventArgs _e) {
    						m_openToolStripMenuItem.Enabled = true;
    					});
    				form.MdiParent = this;				
    				form.Show();
    			}
    		}
    // SingletonForm Class
        using ...
        using System.Threading;
        
        namespace SingletonForm {
        
        	public partial class SingletonForm : Form, IDisposable {
        		static private readonly string m_mutexName = "SingletonForm.SingletonForm";
        		private Mutex m_mutex;
        		private bool m_disposed;
        
        		public SingletonForm() {
        			m_disposed = false;
        
        			// Check to see if there is already a running instance...
        			bool owned;
        			m_mutex = new Mutex(true, m_mutexName, out owned);
        			if (!owned) {
        				// Already running, get out...
        				Close();
        				return;
        			}
        			
        			InitializeComponent();
        		}
        
        		~SingletonForm() {
        			Dispose(false);
        		}
        
        		static public bool Exists {
        			get {
        				bool owned;
        				using (new Mutex(false, m_mutexName, out owned)) {
        					return !owned;
        				}
        			}
        		}
        
        		// IDisposable Members
        		// --------------------------------------------------------------------------
        		#region IDisposable Members
        		public void Dispose() {
        			Dispose(true);
        
        			// Use SupressFinalize in case a subclass of this type implements a finalizer.
        			GC.SuppressFinalize(this);
        		}
        		#endregion	// IDisposable Members
        
        		/// <summary>
        		/// Note: Comment out the Dispose(bool disposing) implementation in your
        		/// SingletonForm.Designer.cs
        		/// </summary>
        		/// <param name="disposing">true if we are disposing.</param>
        		protected override void Dispose(bool disposing) {
        			if (disposing && (components != null)) {
        				components.Dispose();
        			}
        
        			base.Dispose(disposing);
        
        			// If you need thread safety, use a lock around these 
        			// operations, as well as in your methods that use the resource.
        			if (!m_disposed) {
        				if (disposing) {
        					// Code to dispose the managed resources held by the class here...
        					if (m_mutex != null) {
        						m_mutex.Dispose();
        						m_mutex = null;
        					}
        				}
        
        				// Indicate that the instance has been disposed.
        				m_disposed = true;
        			}
        		}
        	};
        };
