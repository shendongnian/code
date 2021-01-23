    public void DoWork() 
    { 
        while (true) 
        { 
            FileData fileData = Model.SelectedValue;
            if (fileData != null) 
            { 
                string name = fileData.FileName; 
                foreach (var action in _actionCollection) 
                { 
                    name = action.Rename(name); 
                } 
                this.Dispatcher.Invoke((Action)()=>  //use Window.Dispatcher
                {
                  label3.Content = fileData.FileName; 
                  label4.Content = name;
                }); 
            } 
            Thread.Sleep(1000); 
        } 
    } 
