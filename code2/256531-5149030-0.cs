    System.Diagnostics.StackFrame f = new System.Diagnostics.StackFrame();
    
                Type t = f.GetMethod().DeclaringType;
    
                string name=t.FullName;
