    private void diagramControl1_AddingNewItem(object sender, DevExpress.XtraDiagram.DiagramAddingNewItemEventArgs e)
    {
        if (e.Item is DiagramConnector)
        {
            e.Item.Tag = ++connectorCount;
        }
        else
        {
            e.Item.Tag = ++shapeCount;
        }
    }
