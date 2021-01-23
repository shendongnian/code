    Stack<Form> stack = new Stack<Form>();
                foreach (Form f in Forms)
                {
                    if (f is Menu)
                    {
                        //do nothing
                    }
                    else
                    {
                        if (!f.IsDisposed)
                        {
                            stack.Push(f);
                        }
                        
                    }
                }
                for (int i = 0; i < stack.Count; i++)
                {
                    Form temp = stack.Pop();
                    temp.Close();
                }
