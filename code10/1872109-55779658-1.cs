    class Program
    {
        enum Directions
        {
            Up,
            Down,
            None
        }
        static void Main(string[] args)
        {
            DateTime next;     
            bool quit = false;
            ConsoleKeyInfo cki;
            Directions direction = Directions.None;
            Console.Clear();
            Console.CursorVisible = false;
            var m = new Martian();
            var s = new SpaceShip();
            m.Draw(true);
            s.Draw(true);
            do
            {
                // wait for next keypress, or next movement
                next = new DateTime(Math.Min(m.nextMovement.Ticks, s.nextMovement.Ticks));               
                while(!Console.KeyAvailable && DateTime.Now < next)
                {
                    System.Threading.Thread.Sleep(10);
                }
                // was a key pressed?
                if (Console.KeyAvailable)
                {
                    cki = Console.ReadKey(true);
                    switch (cki.Key)
                    {
                        case ConsoleKey.UpArrow:
                            direction = Directions.Up;
                            break;
                        case ConsoleKey.DownArrow:
                            direction = Directions.Down;
                            break;
                        case ConsoleKey.Escape:
                            quit = true;
                            break;
                    }
                }
                // does anything need to move?
                if (DateTime.Now >= m.nextMovement)
                {
                    switch(direction)
                    {
                        case Directions.Up:
                            m.MoveUp();
                            break;
                        case Directions.Down:
                            m.MoveDown();
                            break;
                        case Directions.None:
                            m.UpdateNextMovement();
                            break;
                    }
                }
                if (DateTime.Now >= s.nextMovement)
                {
                    s.MoveToward(m);
                }
            } while (!quit);          
        }
    }
    public abstract class SpaceObject
    {
        public int X;
        public int Y;
        public int MovementDelay;
        public DateTime nextMovement;
        abstract public void Draw(bool Visible);
        public void MoveUp()
        {
            if (this.Y > 0)
            {
                this.Draw(false);
                this.Y--;
                this.Draw(true);     
            }
            this.UpdateNextMovement();
        }
        public void MoveDown()
        {
            if (this.Y < Console.WindowHeight - 1)
            {
                this.Draw(false);
                this.Y++;
                this.Draw(true);       
            }
            this.UpdateNextMovement();
        }
        public void MoveToward(SpaceObject so)
        {
            if (so.Y < this.Y)
            {
                this.MoveUp();
            }
            else if (so.Y > this.Y)
            {
                this.MoveDown();
            }
            else
            {
                this.UpdateNextMovement();
            }
        }
        public void UpdateNextMovement()
        {
            this.nextMovement = DateTime.Now.AddMilliseconds(this.MovementDelay);
        }
    }
    public class Martian : SpaceObject
    {
        
        public Martian()
        {
            this.X = 1;
            this.Y = Console.WindowHeight / 2;
            this.MovementDelay = 100;
            this.nextMovement = DateTime.Now.AddMilliseconds(this.MovementDelay);
        }
        
        public override void Draw(bool Visible)
        {
            Console.SetCursorPosition(this.X, this.Y);
            Console.Write(Visible ? "M" : " ");
        }
    }
    public class SpaceShip : SpaceObject
    {
        public SpaceShip()
        {
            this.X = Console.WindowWidth - 2;
            this.Y = Console.WindowHeight / 2;
            this.MovementDelay = 750;
            this.nextMovement = DateTime.Now.AddMilliseconds(this.MovementDelay);
        }
        public override void Draw(bool Visible)
        {
            Console.SetCursorPosition(this.X, this.Y);
            Console.Write(Visible ? "S" : " ");
        }
    }
