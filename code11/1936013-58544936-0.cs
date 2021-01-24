    public class RendererEx : ToolStripProfessionalRenderer {
      protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e) {
        //base.OnRenderMenuItemBackground(e);
        e.Item.BackColor = Color.Black;
      }
    }
