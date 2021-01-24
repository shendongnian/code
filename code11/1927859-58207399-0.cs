            static IEnumerable<IEnumerable<T>> Permutations<T>(IEnumerable<T> set, int size)
            {
                Stack<IList<T>> stack = new Stack<IList<T>>();
                foreach(var item in set)
                {
                    var list = new List<T>() { item };
                    stack.Push(list);
                }
                
                while(stack.Count>0)
                {
                    var next = stack.Pop();
                    if(next.Count==size)
                    {
                        yield return next;
                    }
                    else
                    {
                        
                        foreach(var item in set)
                        {
                            var list = new List<T>();
                            list.AddRange(next);
                            list.Add(item);
                            stack.Push(list);
                        }
                    }
                }
            }
