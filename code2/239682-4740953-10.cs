    public class ShapeDrawInstructionsRegistry
    {
        private static Dictionary<Type, IDrawInstructions> _registry = new Dictionary<Type, IDrawInstructions>();
    
        public static void Register<T>(IDrawInstructions instructions) where T: Shape
        {
            var type = typeof (T);
            if(_registry.ContainsKey(type))
                _registry[type] = instructions;
            else
            {
                _registry.Add(type, instructions);
            }
        }
    
        public static IDrawInstructions Lookup(Shape shape)
        {
            var type = shape.GetType();
            if (!_registry.ContainsKey(type)) return null;
            return _registry[type];
        }
    }
    
    public class SquareDrawInstructions: IDrawInstructions
    {
        public void Draw(Shape shape, IShapeRenderer renderer)
        {
            var square = shape as Square;
            if (square == null) throw new Exception();
            // draw 4 sides
        }
    }
    
    
    
    // in your global.asax.cs or bootstrapper class
    ShapeDrawInstructionsRegistry.Register<Square>(new SquareDrawInstructions());
    ShapeDrawInstructionsRegistry.Register<Triangle>(new TriangleDrawInstructions());
    
    // your loop
    var renderer = new HtmlRenderer();
    foreach (var shape in shapes)
    {
        var instructions = ShapeDrawInstructionsRegistry.Lookup(shape);
        instructions.Draw(shape, renderer);
    }
