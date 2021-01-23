       public void DrawGripper(PaintEventArgs e) {
           if (VisualStyleRenderer.IsElementDefined(
               VisualStyleElement.Status.Gripper.Normal)) {
               VisualStyleRenderer renderer = new VisualStyleRenderer(VisualStyleElement.Status.Gripper.Normal);
               Rectangle rectangle1 = new Rectangle((Width) - 18, (Height) - 20, 20, 20);
               renderer.DrawBackground(e.Graphics, rectangle1);
           }
       }
