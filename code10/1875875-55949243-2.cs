    private void UpdadeControl(ListOfUpdateMethods list, Control control)
    {
        // this method can't added the UI operate. 
        // If you added the UI operate delegate. It will throw the exception.
        list.ExecutaMetodosPreAtualizacao();
    
        if (control.InvokeRequired)
        {
            // you can use Action delegate. Action delegate is so good.
            var action = new Action<ListOfUpdateMethods, Control>(UpdadeControl);
            control.Invoke(action, new object[] { list, control });
        }
        else
        {
            //Execute methods needed to update control
            list.ExecutaMetodosAtualizacao();
    
        }
    }
