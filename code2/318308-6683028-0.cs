    PopupContainerEdit edit = new PopupContainerEdit();
            Controls.Add(edit);
            PopupContainerControl pControl = new PopupContainerControl();
            Controls.Add(pControl);
            TreeList tl = new TreeList();
            tl.Columns.Add().Visible = true;
            tl.AppendNode(new object[] { "123" }, null);
            pControl.Controls.Add(tl);
            edit.Properties.PopupControl = pControl;
