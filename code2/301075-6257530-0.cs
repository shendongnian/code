    public void InvokeIfNecessary(this Control target, Action<Control> action)
    {
       if(target.InvokeRequired)
          target.Invoke((MethodInvoker)(()=>action(target)));
       else
          action(target);      
    }
    
    //usage
    
    myForm.InvokeIfNecessary(f=>f.Show());
