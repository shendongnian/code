        public delegate void UndoRedoCallback(int count);
        private void DrawDropDown(ToolStripSplitButton button, string action, IEnumerable<string> commands, UndoRedoCallback callback)
        {
            int width = 277;
            int listHeight = 181;
            int textHeight = 29;
            Panel panel = new Panel()
            {
                Size = new Size(width, textHeight + listHeight),
                Padding = new Padding(0),
                Margin = new Padding(0),
                BorderStyle = BorderStyle.FixedSingle,
            };
            Label label = new Label()
            {
                Size = new Size(width, textHeight),
                Location = new Point(1, listHeight - 2),
                TextAlign = ContentAlignment.MiddleCenter,
                Text = String.Format("{0} 1 Action", action),
                Padding = new Padding(0),
                Margin = new Padding(0),
            };
            ListBox list = new ListBox()
            {
                Size = new Size(width, listHeight),
                Location = new Point(1,1),
                SelectionMode = SelectionMode.MultiSimple,
                ScrollAlwaysVisible = true,
                Padding = new Padding(0),
                Margin = new Padding(0),
                BorderStyle = BorderStyle.None,
                Font = new Font(panel.Font.FontFamily, 9),
            };
            foreach (var item in commands) { list.Items.Add(item); }
            if (list.Items.Count == 0) return;
            list.SelectedIndex = 0;
            ToolStripControlHost toolHost = new ToolStripControlHost(panel)
            {
                Size = panel.Size,
                Margin = new Padding(0),
            };
            ToolStripDropDown toolDrop = new ToolStripDropDown()
            {
                Padding = new Padding(0),
            };
            toolDrop.Items.Add(toolHost);
            panel.Controls.Add(list);
            panel.Controls.Add(label);
            toolDrop.Show(this, new Point(button.Bounds.Left + button.Owner.Left, button.Bounds.Bottom + button.Owner.Top));
            // *Note: These will be "up values" that will exist beyond the scope of this function
            int index = 1;
            int lastIndex = 1;
            list.Click += (sender, e) => { toolDrop.Close(); callback(index); };
            list.MouseMove += (sender, e) =>
            {
                index = Math.Max(1, list.IndexFromPoint(e.Location) + 1);
                if (lastIndex != index)
                {
                    int topIndex = Math.Max(0, Math.Min(list.TopIndex + e.Delta, list.Items.Count - 1));
                    list.BeginUpdate();
                    list.ClearSelected();
                    for (int i = 0; i < index; ++i) { list.SelectedIndex = i; }
                    label.Text = String.Format("{0} {1} Action{2}", action, index, index == 1 ? "" : "s");
                    lastIndex = index;
                    list.EndUpdate();
                    list.TopIndex = topIndex;
                }
            };
            list.Focus();
        }
