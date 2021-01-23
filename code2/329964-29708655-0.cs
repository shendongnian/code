        protected override Expression VisitConstant(ConstantExpression node)
        {
                        MemberExpression prevNode;
                        var val = node.Value;
                        while ((prevNode = PreviousNode as MemberExpression) != null)
                        {
                            var fieldInfo = prevNode.Member as FieldInfo;
                            var propertyInfo = prevNode.Member as PropertyInfo;
                            if (fieldInfo != null)
                                val = fieldInfo.GetValue(val);
                            if (propertyInfo != null)
                                val = propertyInfo.GetValue(val);
                            Nodes.Pop();
                        }
                        // we got the value
                        // now val = constant we was looking for
            return node;
        }
