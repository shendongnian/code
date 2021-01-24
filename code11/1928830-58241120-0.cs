        public interface IDrawObject
        {
            void drawGraph(List<int> list);
        }
        public class DrawObject1 : IDrawObject
        {
            public void drawGraph(List<int> list)
            {
                Console.WriteLine("object1.drawGraph()");
            }
        }
        public class DrawObject2 : IDrawObject
        {
            public void drawGraph(List<int> list)
            {
                Console.WriteLine("object2.drawGraph()");
            }
        }
