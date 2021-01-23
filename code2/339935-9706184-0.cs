     foreach (var column in treeListNode.Columns)
                    {
                        var tc= column as TreeListColumn;
                        if (tc!= null && tc.Name == columnID)
                        {
                            var originalType = tc.UnboundType;
                            tc.UnboundType = UnboundColumnType.Object;
                            treeListNode[columnID] = null;                             
                            tc.UnboundType = originalType;
                            break;
                        }
                    }
