    private void MyThread(object param)
    {
       MyForm form = (MyForm) param; // pass your form as your param
       DoWork(); // Whatever it is you are doing on your thread
       form.Invoke(new MethodInvoker(form.NotifyComplete)); // Invokes on main thread
    }
    
    public void Button_OnClick(object sender, EventArgs args)
    {
       ThreadPool.QueueUserWorkItem(new Action<object>(MyThread), this);
    }
    
    
    private void NotifyComplete()
    {
       // update your controls here
       ...
    }
