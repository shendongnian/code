    private ObservableCollection<ObservableCollection<Node>> FindCollection(ObservableCollection<Node> collection, ObservableCollection<ObservableCollection<Node>> retVal){
        foreach ( Nodes node in collection){
            if (node.Nodes.Count > 0){
                collectionToCheck = node.Nodes;
                FindCollection(collectionToCheck,retVal);
            }
            if ( node.Name == SearchPattern ){
                retval.Add(collection);
                break;
            }
        }
        return retVal;
    }
