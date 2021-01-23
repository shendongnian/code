    CommandBinding removeBinding=null;
    foreach(CommandBinding cb in navigationWindow.CommandBindings){
     if(cb.Command==NavigationCommand.Refresh){
       removeBinding=cb;
       break;
     }
     if(removeBinding != null){
       navigationWindow.CommandBindings.Remove(removeBinding);
     }
    
    }
