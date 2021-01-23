            for (int i = 0; i < model.Children.Count; i++)
            {
                var child = model.Children[i] as ModelVisual3D;
                UnionRect(child, ref rect3D);
            }
            if (model.Content != null)
                rect3D.Union(model.Content.Bounds);
        }
