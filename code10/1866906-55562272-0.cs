    using System;
    
    namespace ConsoleApplication6
    {
        class Program
        {
            static void Main(string[] args)
            {
                Martian m = new Martian();
                SpaceShip s = new SpaceShip();
    
                const int MaxY = 100;
    
                m.Draw();
                s.X = m.X + 100;
                s.Y = m.Y;
                s.Draw();
    
                ConsoleKeyInfo keyInfo;
                while (true)
                {
                    keyInfo = Console.ReadKey(true);
                    Console.Clear();
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.UpArrow:
                            if (m.Y > 0)
                            {
                                if (m.Y < MaxY)
                                {
                                    m.Y--;
                                }
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            m.Y++;
                            break;
                    }
                    m.Draw();
                    s.X = m.X + 100;
                    s.Y = m.Y;
                    s.Draw();
                }
            }
        }
    
        public abstract class GameObject
        {
            public int X { get; set; }
            public int Y { get; set; }
    
            public abstract void Draw();
        }
    
        public class Martian : GameObject
        {
            public override void Draw()
            {
                Console.SetCursorPosition(X, Y);
                Console.WriteLine("M");
            }
        }
    
        public class SpaceShip : GameObject
        {
            public override void Draw()
            {
                Console.SetCursorPosition(X, Y);
                Console.WriteLine("S");
            }
        }
    
    }
