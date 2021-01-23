            var menu = new ContextMenuStrip();
            var item = new ToolStripMenuItem("test");
            item.Image = Properties.Resources.Example;
            item.Click += OnClick;
            menu.Items.Add(item);
            menu.Show(this, this.PointToClient(MousePosition));
