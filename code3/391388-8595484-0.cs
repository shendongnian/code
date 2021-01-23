        private IEnumerable<Control> GetControlHierarchy(Control root)
        {
            var stack = new Stack<Control>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                var control = stack.Pop();
                yield return control;
                if (control.HasChildren)
                    foreach (var child in control.Controls)
                        if (child is Control)
                            stack.Push(child as Control);
            }
        }
