    //something like this
    bool isBinding = false;
    
    //when binding
    isBinding = true;
    listbox.DataBind();
    
    //in the selection change event
    if(isBinding)
    {
        isBinding = false;
        return;
    }
