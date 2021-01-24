VisualNode visualNode = new VisualNode(item.Name, new ObjectVisualizer(localView));
visualNode.AddShape(item.Shape, c, (double)c.A / 255);
foreach(var x in visualNode.AisShapes)
{
    x.SetMaterial(OCGraphic3d_NameOfMaterial.Graphic3d_NOM_PLASTIC);
}
Visualizer.RootNode.Children.Add(visualNode);
visualNode.Show();
