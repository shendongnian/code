    string tree = "AB-12-AC-14";
    
                Stack<BaseNode> TreeStack = new Stack<BaseNode>();
                Stack<BaseNode> TreeStack1 = new Stack<BaseNode>();
                BaseNode temp1 = new BaseNode();
                BaseNode temp2 = new BaseNode();
                for (int i = 0; i < tree.Length; i++)
                {
                    VariableNode varNode = new VariableNode();
                    NumericalNode numNode = new NumericalNode();
                    if (CheckExpressions(tree[i])) // if the character is an operator
                    {
                        OperatorNode expression = new OperatorNode(tree[i]);
    
                        //check priority should pass the current operator to really check for priority
                        if (CheckPriority() || TreeStack1.Count == 0)
                        {
                            TreeStack1.Push(expression);
                        }
                        else
                        {
                            // assuming binary operators only
                            temp1 = TreeStack.Pop();
                            temp2 = TreeStack.Pop();
                            expression.Right = temp1;
                            expression.Left = temp2;
                            TreeStack.Push(expression);
                            // need to check if there are more operators on stack1 are they higher priority then current operator
                            // if they are then pop them and apply them too
                        }
                    }
                    else if (!CheckExpressions(tree[i]))
                    {
                        if (Char.IsLetter(tree[i]))
                        {
                            while (Char.IsLetter(tree[i])) // for the variable node
                            {
                                varNode.name += tree[i];
                                if (i + 1 == tree.Length)
                                {
                                    break;
                                }
                                i++;
                            }
                            TreeStack.Push(varNode);
                            if (i + 1 != tree.Length)
                            {
                                i--;
                            }
                        }
                        else if (Char.IsDigit(tree[i])) // for constant value
                        {
                            int zero = 0; // for appending the numbers to combine them
                            while (i < tree.Length && Char.IsDigit(tree[i])) // need to check for length otherwise index will go out of bounds
                            {
                                if (zero == 0)
                                {
                                    zero = tree[i] - '0';
                                }
                                else
                                {
                                    zero = int.Parse(zero.ToString() + tree[i].ToString());
                                }
                                if (i < tree.Length)
                                {
                                    i++;
                                }
                            }
                            if (i + 1 != tree.Length)
                            {
                                i--;
                            }
                            numNode.number = zero;
                            TreeStack.Push(numNode);
                        }
                    }
                }
    
                // finish any remaining operators and push the final expression on the stack
                while (TreeStack1.Count!=0)
                {
                    OperatorNode expression1 = new OperatorNode(((OperatorNode)TreeStack1.Pop()).v);
                    expression1.Right = TreeStack.Pop();
                    expression1.Left = TreeStack.Pop();
                    TreeStack.Push(expression1);
                }
