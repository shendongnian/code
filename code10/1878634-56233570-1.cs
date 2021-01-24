    internal void SortPaths(JsonNode root, Byte[] JSONdata, String id)
    {
        Stack<BrowseNode> s = new Stack<BrowseNode>(); // BreadFirst stack
        s.Push(new BrowseNode(ref root, JSONdata));
        List<NodeComparer2> rows = new List<NodeComparer2>(); // List 2B sort @end
        HashSet<JsonNode> processed = new HashSet<JsonNode>(); // in case of circles...
        BrowseNode element;
        while (s.Count > 0)
        {
            element = s.Pop();
            if (null != element.NodeRawData.NodeBelow)
            {
                if (null != element.NodeRawData.NextTo) s.Push(element.Next_Viewer);
                s.Push(element.Node_Viewer);
            }
            else if (null != element.NodeRawData.NextTo)
            { // Array of elements here
                if (processed.Contains(element.Parent_Viewer.NodeRawData)) continue;
                else processed.Add(element.Parent_Viewer.NodeRawData);
                BrowseNode keyNode = element;
                ParentNode pn = new ParentNode(element);
                List<NodeComparer> lastChildrens = new List<NodeComparer>();
                String key = "";
                while (null != keyNode)
                {
                    if (JsonTag.JSON_ARRAY == keyNode.Tag_Viewer || JsonTag.JSON_OBJECT == keyNode.Tag_Viewer) s.Push(keyNode);
                    if (id != null && id == keyNode.KeyPrint) { // If ID matche this one, use it in path not as column value
                        key = $"\\{keyNode.Value_Viewer}";
                    }
                    lastChildrens.Add(new NodeComparer(keyNode, JSONdata));
                    keyNode = keyNode.Next_Viewer;
                }
                lastChildrens.Sort();
                pn.SetChild(lastChildrens[0].element); // connect 1st sorted to their parent
                int count = lastChildrens.Count;
                lastChildrens[count - 1].element.NodeRawData.SetNextTo(null); // clear last's Next
                int level = lastChildrens[count - 1].element.Level_Viewer;
                for (int i = 1; i < count; i++)
                { // reconnect array in sort order
                    lastChildrens[i - 1].element.NodeRawData.NextTo = lastChildrens[i].element.NodeRawData;
                }
                key = (element.Parent_Viewer ?? element).Path(true) + key; // Create path and append ID value
                for (int i = 0; i < count; i++)
                { // Create object for last step sort
                    NodeComparer item = lastChildrens[i];
                    if (item.element.Tag_Viewer != JsonTag.JSON_ARRAY
                        && item.element.Tag_Viewer != JsonTag.JSON_OBJECT)
                        key += $"\t{item.element.KeyPrint}\t'{item.element.Value_Viewer}";
                    else {
                        lastChildrens.Remove(item);
                        i--;
                        count--;
                    }
                }
                rows.Add(new NodeComparer2() { Key = key, Level = level, elements = lastChildrens });
            }
        }
        rows.Sort(); // Sort rest according 2 full paths
        int rowsCount = rows.Count;
        BrowseNode pred = new BrowseNode(ref root, JSONdata), current = null;
        VisualNode3 check = new VisualNode3(ref root, JSONdata, 10000);
        for (int i = 0; i < rowsCount; i++)
        { // Fix connections in order of sorted rows
            current = rows[i].elements[0].element;
            if (current.Level_Viewer > pred.Level_Viewer) {
                FixArraysOrder(current);
            }
            while (current.Level_Viewer < pred.Level_Viewer) pred = pred.Parent_Viewer;
            current = GetConnectionPath(pred, current);
            while (pred.Level_Viewer > current.Level_Viewer) pred = pred.Parent_Viewer;
            if (pred.Level_Viewer == 0) {
                pred.NodeRawData = current.NodeRawData;
                pred.NodeRawData.NextTo = null;
            } else {
                pred.NodeRawData.NextTo = current.NodeRawData;
                if(current.NodeRawData.Tag == JsonTag.JSON_ARRAY
                || current.NodeRawData.Tag == JsonTag.JSON_OBJECT) current.NodeRawData.NextTo = null;
            }
            pred = rows[i].GetLast;
        }
    }
