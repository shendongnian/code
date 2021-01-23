      void RemoveByPath(YourClass currentNode, int[] path)
      {
           for (int i = 0; i < path.Length - 1; i++)
           {
                currentNode = currentNode.ChildElements[path[i]];
           }
           currentNode.ChildElements.RemoveAt(path[path.Length-1));
      }
