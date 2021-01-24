    public abstract class Shape
    {
        protected string description;
        protected Color edgeColor;
        protected Pen pen;
        public Weergave Weergave;
        
        //public line lijnen;
        //public List<int> lijst;
        public virtual void Draw(ShapeDisplay sd, Graphics canvas)
        {
            // we define a uniform pen size for all shapes
            //pen = new Pen(this.edgeColor, 3);
            Weergave.Draw1(sd, canvas);
        }
    }
    public abstract class Weergave
    {
        protected Color randkleur;
        protected Pen pen;
        public virtual void Draw1(ShapeDisplay sd, Graphics canvas)
        {
            pen = new Pen(this.randkleur, 3);
        }
    }
    public class Graphical : Weergave
    {
        public override void Draw1(ShapeDisplay sd, Graphics canvas)
        {
            foreach (var item in) 
        }
    }
