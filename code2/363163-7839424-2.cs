    if (Application.Current.Dispatcher.CheckAccess()) {
    	network_links.Add(new NetworkLinkVM(link, start_node, end_node));
    }
    else {
    	Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(()=>{
    	    network_links.Add(new NetworkLinkVM(link, start_node, end_node));
        }));
    }
