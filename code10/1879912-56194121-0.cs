        public interface ILibraryWidget
        {
            void OnInit();
            void Update();
            void Render();
        }
    
        public abstract class BaseWidget : ILibraryWidget
        {
            public void OnInit()
            {
                throw new NotImplementedException();
            }
    
            public void Render()
            {
                throw new NotImplementedException();
            }
    
            public void Update()
            {
                throw new NotImplementedException();
            }
        }
    
        public class Window : ILibraryWidget
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int W { get; set; }
            public int H { get; set; }
    
            public string Name { get; set; }
            public string Text { get; set; }
    
            public Window()
            {
    
            }
            public void OnInit()
            {
                Console.WriteLine("Im init");
            }
            public void Update()
            {
                Console.WriteLine("Im update");
            }
    
            public void Render()
            {
                Console.WriteLine("Im render");
            }
        }
    
        public class TextEdit : Window
        {
            public TextEdit()
            {
    
            }
            public new void OnInit()
            {
                Console.WriteLine("Im init text");
            }
            public new void Update()
            {
                Console.WriteLine("Im update text");
            }
    
            public new void Render()
            {
                Console.WriteLine("Im render text");
            }
        }
    
        public class Widget
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int W { get; set; }
            public int H { get; set; }
    
            public string Name { get; set; }
            public string Text { get; set; }
    
            private Window Package { get; set; }
    
            public delegate void Pressed();
    
            //Child Widgets
            public Widget Parent { get; private set; }
            public List<Widget> Children { get; private set; }
    
    
            //Callers
            public Widget()
            {
                Children = new List<Widget>();
            }
    
            public void OnInit()
            {
                (Package as Window).OnInit();
            }
            public void Update()
            {
                (Package as Window).Update();
            }
    
            public void Render()
            {
                (Package as Window).Render();
            }
    
            public static List<Widget> New(string name, string text, int x, int y, int w, int h)
            {
                return new List<Widget> {
                    new Widget { Name = name, Text = text, X = x, Y = y, W = w, H = h }
                };
            }
    
            public static void Main(string[] args)
            {
                Widget testWidget = new Widget
                {
                    Name = "Window0",
                    Text = "",
                    X = 0,
                    Y = 0,
                    W = 256,
                    H = 240,
    
                    //List of Widgets
                    Children = new List<Widget>
                    {
                        new Widget{ Name = "Window0_0", Text = "", X = 0, Y = 0, W = 256, H = 240, },
                        new Widget{ Name = "Window0_1", Text = "", X = 0, Y = 0, W = 256, H = 240, }
                    }
    
                };
    
            }
        }
