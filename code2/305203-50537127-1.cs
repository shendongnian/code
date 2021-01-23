    if (start?.Nodes.Count > 0)
        start = start?.Nodes[0]; //If there are childs, select the first
    else if (start?.NextNode != null)
        start = start?.NextNode; //If there is a sibling, select the sibling
    else
    {
        //In this case, the next node is a sibling of one of the nodes ancestors
        if (start?.Parent?.NextNode != null)
            start = start?.Parent?.NextNode; //the parents sibling is our next node
        else
        {
            //we go the paths along the parents up, until we can go to the next sibling,
            //as long as there exist some parents
            while(start.Level != 0)
            {
                start = start.Parent;
                if (start.NextNode != null)
                {
                    start = start.NextNode;
                    break;
                }
            }
        }
    }
