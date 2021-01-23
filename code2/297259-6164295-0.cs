    public List<Unit> LoadAllUnits(XMLNode rootNode){
        List<Unit> allUnits = new List<Unit>();
        foreach(var childNode in rootNode.ChildNodes){
            allUnits.Add(LoadAllSubUnits(childNode);
        }
        return allUnits;
    }
    private Unit LoadAllSubUnits(XMLNode node){
        Unit u = GetUnitFromCurrentNode(node); // Converts current node into Unit object
        if(root.HasChildNode){
             foreach(var childNode in node.ChildNodes){
                 u.ChildUnits.Add(LoadAllSubUnits(childNode);
             }
        }
        return u;
    }
