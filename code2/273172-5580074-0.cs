    internal delegate void PathDelivery(JPTreeNode treeNode, Period periodInCommon); //Deliver a path through this delegate
    internal class TreeHandler //The main class
    {
        private readonly PathDelivery _pathDelivery;
        // Construct with 
        public TreeHandler(PathDelivery pathDelivery)
        {
            _pathDelivery = pathDelivery; 
        }
        public void HandleNode(IList<SourceRow> jpSource, int level,JPTreeNode parentNode, Period intersectingPeriod)
        {
            int sequenceId = level + 1;
            IList<SourceRow> children = new List<SourceRow>(System.Linq.Enumerable.Where(jpSource, S => S.Id == sequenceId));
            if (children.Count == 0) //The last leaf level... return the path throug PathDelivery delegate if valid dates
            {
                if (intersectingPeriod!= null)
                    _pathDelivery(parentNode, intersectingPeriod); //Only deliver this path if all nodes in path has an intersecting period
            }
            else //This node has children to add
            {
                foreach (SourceRow child in children) //Loop and create children 
                {
                    Stop stop = new Stop(child.Id, child.Period, child.Description); //Value object for child node
                    //Re-calculate the valid period (intersect) for the tree path 
                    Period newIntersect = Period.Intersect(stop.Period, intersectingPeriod); 
                    JPTreeNode childNode = new JPTreeNode(parentNode, stop); //Create the child node 
                    
                    if (parentNode!= null) //If not at root level, add child node to parent node
                        parentNode.ChildNodes.Add(childNode);
                    // Recursive call, handle possible grandchildren (children of this childNode) or finish path
                    HandleNode(jpSource, sequenceId, childNode, newIntersect); 
                }
            }
        }
    }
