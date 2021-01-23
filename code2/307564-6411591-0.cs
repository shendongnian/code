    void updateListbox()
    {
            if (listbox.Dispatcher.Thread != Thread.CurrentThread)
            {
                //invoke this function, because another thread is calling this function
                listbox.Dispatcher.Invoke(new Action(updateListbox));
            }
            else
            {
                //update listbox
            }
    }
