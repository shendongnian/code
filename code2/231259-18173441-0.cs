        if (e.Node == null) return;
        e.Node.Text = e.Node.Text.Substring(6, e.Node.Text.Length - 6);
        e.Node.BeginEdit();
    }
    private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
    {
        e.Node.Text = "Name: " + e.Label;
        e.CancelEdit = true;
    }
