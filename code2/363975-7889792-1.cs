    private void DrawSubtreeLinks(Graphics gr) {
        foreach(TreeNode<T> child in Children) {
            PointF p = new PointF(Center.X, child.Center.Y);
            gr.DrawLine(MyPen, Center, p);
            gr.DrawLine(MyPen, p, child.Center);
            child.DrawSubtreeLinks(gr);
        }
    }
