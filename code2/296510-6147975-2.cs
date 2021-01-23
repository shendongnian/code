        interface IPaintingContext
        {
            //Should not be object. But my System.Drawing knowledge is limited
            object DrawingSurface { get; set; }
        }
        interface IPaintable
        {
            void Draw(IPaintingContext context);
        }
        class AwesomeDecal : IPaintable
        {
            public void Draw(IPaintingContext paintable)
            {
                // draw decal
            }
        }
        class ComplexPaintableObject : IPaintable
        {
            public ComplexPaintableObject(IEnumerable<IPaintable> paintable)
            {
                // add background, border 
            }
        }
