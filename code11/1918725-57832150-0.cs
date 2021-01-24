     ITcSmTreeItem routeConfiguration = systemManager.LookupTreeItem("TIRR"); // Route Settings
    
     // The following XML string triggers a Broadcast Search if consumed on TIRR node
    string xml = 
    	@"<TreeItem>
    		<RoutePrj>
    			<TargetList>
    				<BroadcastSearch>true</BroadcastSearch>
    			</TargetList>
    		</RoutePrj>
    	</TreeItem>";
    
    routeConfiguration.ConsumeXml(xml); // Trigger Broadcast Search
    string producedXml = routeConfiguration.ProduceXml(); // Get the result 
           
