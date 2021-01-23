    using System;
    using System.Collections.Generic;
    using System.Drawing;
    class Room
    {
        public int X
        {
            get;
            set;
        }
    }
    struct Program
    {
        static void Main()
        {
            Dictionary<Point, Room> world = new Dictionary<Point, Room>();
            world.Add(new Point(0, 0), new Room() { X = 0 });
            world.Add(new Point(2, 3), new Room() { X = 2 });
            Room room = world[new Point(2, 3)];
            Console.WriteLine(room.X);
            Console.ReadKey();
        }
    }
