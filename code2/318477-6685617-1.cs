    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1 {
    	public partial class Form2 : Form {
    		public Form2() {
    			InitializeComponent();
    			
    			CustomCheckBox.CheckChanged += (object sender, EventArgs e) => {
    				if (sender != m_customCheckBox) { m_customCheckBox.Checked = CustomCheckBox.GetCheck(); }
    			};
    
    			FormClosed += (object _sender, FormClosedEventArgs _e) => {
    				CustomCheckBox.CheckChanged -= (object __sender, EventArgs __e) => { };
    			};
    				
    		}
    	};
    };
    
    
    
    ////////////////////////////////////////////////
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1 {
    
    	public class CustomCheckBox : CheckBox {
    		static private bool? m_checked = null;
    		static private object m_synchRoot = new object();
    		static public event EventHandler CheckChanged;
    
    		public CustomCheckBox() {
    			if (HasCheckValue) {
    				// Do this BEFORE we set up the CheckChanged event so that
    				// we do not needlessly kick off the CustomCheckBox.CheckChanged
    				// event for any other existing CustomCheckBoxes (as they already
    				// have their Checked property properly set)...
    				Checked = CustomCheckBox.GetCheck();
    			}
    			this.CheckedChanged += new EventHandler(OnCheckedChanged);
    		}		
    
    		protected void OnCheckedChanged(object sender, EventArgs e) {			
    			if (CustomCheckBox.HasCheckValue && this.Checked == CustomCheckBox.GetCheck()) {
    				return;
    			} else {
    				CustomCheckBox.SetCheck(this.Checked);
    				if (CustomCheckBox.CheckChanged != null) {
    					CustomCheckBox.CheckChanged(sender, e);
    				}
    			}
    		}
    
    		static public bool HasCheckValue {
    			get {
    				lock (m_synchRoot) {
    					return m_checked.HasValue;
    				}
    			}
    		}
    
    		static public bool GetCheck() {
    			lock (m_synchRoot) {
    				return m_checked.Value;
    			}
    		}
    
    		static private void SetCheck(bool _check) {
    			lock (m_synchRoot) {
    				m_checked = _check;
    			}
    		}
    	};
    };
