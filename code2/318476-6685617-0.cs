    CustomCheckBox.CheckChanged += (object sender, EventArgs e) => {
                				if (sender != m_customCheckBox) { m_customCheckBox.Checked = CustomCheckBox.GetCheck(); }
                			};
        
        
         public class CustomCheckBox : CheckBox {
            		static private bool? m_checked = null;
            		static private object m_synchRoot = new object();
            		static public event EventHandler CheckChanged;
            
            		public CustomCheckBox() {
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
