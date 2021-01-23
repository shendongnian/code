	private Node CreateXBonezNodes() {
		Node universeNode = new Node("Universe");
		Node solarSystemNode = new Node("Solar System");
		Node planetNode = new Node("Planet");
		Node meteorNode = new Node("Meteor");
		Node moonNode = new Node("Moon");
		
		//Now define the hierarchy
		universeNode.ChildNodes.Add(solarSystemNode);
		solarSystemNode.ChildNodes.Add(planetNode);
		solarSystemNode.ChildNodes.Add(meteorNode);
		planetNode.ChildNodes.Add(moonNode);
		
		return universeNode;
	}
