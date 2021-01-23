        IEnumerable<Control> EnumControls(Control top)
        {
            Queue<Control> todo = new Queue<Control>();
            todo.Enqueue(top);
            while (todo.Count > 0)
            {
                Control c = todo.Dequeue();
                yield return c;
                foreach (Control ch in c.Controls)
                    todo.Enqueue(ch);
            }
        }
