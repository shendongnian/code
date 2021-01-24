private (double weight, NodeDirection? Direction) GetDistanceAndDirection(Node nodeOne, Node nodeTwo)
        {
            var x1 = nodeOne.Row;
            var y1 = nodeOne.Col;
            var x2 = nodeTwo.Row;
            var y2 = nodeTwo.Col;
            if (x2 < x1 && y1 == y2)
            {
                switch (nodeOne.Direction)
                {
                    case NodeDirection.Up:
                        return (1, NodeDirection.Up);
                    case NodeDirection.Right:
                        return (2, NodeDirection.Up);
                    case NodeDirection.Left:
                        return (2, NodeDirection.Up);
                    case NodeDirection.Down:
                        return (3, NodeDirection.Up);
                }
            }
            else if (x2 > x1 && y1 == y2)
            {
                switch (nodeOne.Direction)
                {
                    case NodeDirection.Up:
                        return (3, NodeDirection.Down);
                    case NodeDirection.Right:
                        return (2, NodeDirection.Down);
                    case NodeDirection.Left:
                        return (2, NodeDirection.Down);
                    case NodeDirection.Down:
                        return (1, NodeDirection.Down);
                }
            }
            if (y2 < y1 && x1 == x2)
            {
                switch (nodeOne.Direction)
                {
                    case NodeDirection.Up:
                        return (2, NodeDirection.Left);
                    case NodeDirection.Right:
                        return (3, NodeDirection.Left);
                    case NodeDirection.Left:
                        return (1, NodeDirection.Left);
                    case NodeDirection.Down:
                        return (2, NodeDirection.Left);
                }
            }
            else if (y2 > y1 && x1 == x2)
            {
                switch (nodeOne.Direction)
                {
                    case NodeDirection.Up:
                        return (2, NodeDirection.Right);
                    case NodeDirection.Right:
                        return (1, NodeDirection.Right);
                    case NodeDirection.Left:
                        return (3, NodeDirection.Right);
                    case NodeDirection.Down:
                        return (2, NodeDirection.Right);
                }
            }
            return default;
        }
and then AddNodeToHeapMethod()
private void AddNodeToHeap(Node currentNode, Node nextNode, Node endNode, MinHeap<Node> heap)
        {
            if (nextNode.IsVisited)
                return;
            var (additionalWeight, direction) = this.GetDistanceAndDirection(currentNode, nextNode);
            var g = currentNode.GScore+ nextNode.Weight + additionalWeight;
            var h = this.ManhattanDistance(nextNode, endNode);
            if (g < nextNode.GScore)
            {
                nextNode.GScore= g;
                nextNode.H = h;
                nextNode.PreviousNode = currentNode;
                nextNode.IsVisited = true;
            }
            currentNode.Direction = direction;
            heap.Add(nextNode);
        }
  [1]: https://i.stack.imgur.com/92YTe.png
  [2]: https://i.stack.imgur.com/P3BId.png
