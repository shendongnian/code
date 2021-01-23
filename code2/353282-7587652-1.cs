     private void TraverseParseTree()
            {
                if (_parseTree == null) return;
                ParseNodeRec(_parseTree.Root);
            }
            private void ParseNodeRec(ParseTreeNode node)
            {
                if (node == null) return;
                string functionName = "";
                if (node.ToString().CompareTo("class_declaration") == 0)
                {
                    ParseTreeNode tmpNode = node.ChildNodes[2];
                    currentClass = tmpNode.AstNode.ToString();
                }
                if (node.ToString().CompareTo("method_declaration") == 0)
                {
                    foreach (var child in node.ChildNodes)
                    {
                        if (child.ToString().CompareTo("qual_name_with_targs") == 0)
                        {
                            ParseTreeNode tmpNode = child.ChildNodes[0];
                            while (tmpNode.ChildNodes.Count != 0)
                            { tmpNode = tmpNode.ChildNodes[0]; }
                            functionName = tmpNode.AstNode.ToString();
                        }
                        if (child.ToString().CompareTo("method_body") == 0)  //method_declaration
                        {
                            int statementsCount = FindStatements(child);
                            //Register bad smell
                            if (statementsCount>(((LongMethodsOptions)this.Options).MaxMethodLength))
                            {
                                //function.StartPoint.Line
                                int functionLine = GetLine(functionName);
                                foundSmells.Add(new BadSmellRegistry(name, functionLine,currentFile,currentProject,currentSolution,false));
                            }
                        }
                    }
                }
                foreach (var child in node.ChildNodes)
                { ParseNodeRec(child); }
            }
