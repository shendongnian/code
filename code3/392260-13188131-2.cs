    public Point3D GetCenter(ModelVisual3D model)
    {
        var rect3D = Rect3D.Empty;
        UnionRect(model, ref rect3D);
        _center = new Point3D((rect3D.X + rect3D.SizeX / 2), (rect3D.Y + rect3D.SizeY / 2), (rect3D.Z + rect3D.SizeZ / 2));
        return _center;
    }
    
    private void UnionRect(ModelVisual3D model, ref Rect3D rect3D)
    {
        for (int i = 0; i < model.Children.Count; i++)
        {
            var child = model.Children[i] as ModelVisual3D;
            UnionRect(child, ref rect3D);
        }
        if (model.Content != null)
            rect3D.Union(model.Content.Bounds);
    }
