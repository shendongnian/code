    private void ShowOrActivateForm<T>() where T : Form
            {
                var k = MdiChildren.Where(c => c.GetType() == typeof(T)).FirstOrDefault();
                if (k == null) 
                {                    
                
                    k = (Form)Activator.CreateInstance(typeof(T));
                    k.MdiParent = this;
                    k.Show();
                }
                else
                {
                    k.Activate();                
                }            
            }
