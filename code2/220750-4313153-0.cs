    private void button1_Click(object sender, EventArgs e)
        {
                    StackTrace st = new StackTrace(true);
            StackFrame[] fram = st.GetFrames();
            foreach (StackFrame sf in fram)
            {
                sf.GetFileColumnNumber();
                sf.GetFileLineNumber();
                sf.GetFileName();
                sf.GetILOffset();
                sf.GetMethod();
                
            }
        }  
