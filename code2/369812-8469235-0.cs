    public class MainGameClass {
        public static Rectangle StarBounds;
    
        public void HandleInput () {
            // if GameFunctions.ClickedWithinStarBounds(mouse)
            // GameFunctions.OnClickStarBounds()
        }
    }
    
    public class GameFunctions {
        public static void ClickedWithinStarBounds(MouseState mouse) {
            // create a rectangle around the mouse (ie. cursor) for the detection area
            // return left mouse button is down or pressed && IsWithinStarBounds
        }
        public static bool IsWithingStarBounds(Rectangle area) {
            return (MainGameClass.StarBounds.Intersects(area);
        }
    
        public static void OnClickStarBounds() {
            MainGameClass.StarBounds = Rectangle.Empty;
        }
    }
