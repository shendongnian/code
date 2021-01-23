    public class FooPicbox : PictureBox {
    
       protected override void OnMouseDown( MouseEventArgs e ) {
          base.OnMouseDown( e );
          /* Insert code here */
          /* Example: */
          base.OnMouseUp( e );
          base.OnMouseClick( e );
       }
    }
