      using System.Linq;
        
        		 public static Form IsFormAlreadyOpen(Type FormType)        {		
        			return Application.OpenForms.Where( f => f.GetType() == FormType).FirstOrDefault();
        		}
        
                private void ClickEvent<T>(object sender, EventArgs e) where T: Form, new() 
        		{
                    T selectedForm = IsFormAlreadyOpen(typeof(T); 
                    if (selectedForm == null)             {
                        (new T() { MdiParent = this; }).Show()
                    }
                    else {	
        				this.MdiChildren.Where(o => o == selectedForm).ForEach(
        				    openForm => { 
        						selectedForm.WindowState = (selectedForm.WindowState == FormWindowState.Minimized) ? FormWindowState.Normal : selectedForm.WindowState;
        						openForm.Select();
        				    }
        				);
        			}
                }
        		private void form1ToolStripMenuItem_Click(object sender, EventArgs e) 		{
        			ClickEvent<Form1>(sender, e)
        		}
                
                private void form2ToolStripMenuItem_Click(object sender, EventArgs e) {
                   ClickEvent<Form2>(sender, e) 
                }
