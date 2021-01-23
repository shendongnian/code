    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    
    struct PointD 
    {
        public int X;
        public int Y;
        public int Z;
    }
    
    class PerfTest
    {
        List<PointD> _pCoord3Points = new List<PointD>();
    
        int checkPointIndexOf(PointD pt)
        {
            return _pCoord3Points.IndexOf(pt);  
        }
    
        int checkPointForBreak(PointD pt)
        {
            int retIndex = -1;
            for (int i = 0; i < _pCoord3Points.Count; i++)
            {
                PointD otherPt = _pCoord3Points[i];
                if ((pt.X == otherPt.X) &&
                    (pt.Y == otherPt.Y) &&
                    (pt.Z == otherPt.Z))
                    retIndex = i;
                break;
            }
            return retIndex;
        }
    
        void init()
        {
            for (int x = 0; x < 100; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    for (int z = 0; z < 10; z++)
                    {
                        PointD pt = new PointD() { X = x, Y = y, Z = z };
                        _pCoord3Points.Add(pt);
                    }
                }
            }
        }
    
        static void Main(string[] args)
        {
            PerfTest test = new PerfTest();
            test.init();
            Stopwatch sw = Stopwatch.StartNew();
            for (int x = 0; x < 100; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    for (int z = 0; z < 10; z++)
                    {
                        PointD pt = new PointD() { X = x, Y = y, Z = z };
                        test.checkPointIndexOf(pt);
                    }
                }
            }
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            sw = Stopwatch.StartNew();
            for (int x = 0; x < 100; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    for (int z = 0; z < 10; z++)
                    {
                        PointD pt = new PointD() { X = x, Y = y, Z = z };
                        test.checkPointForBreak(pt);
                    }
                }
            }
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
        }
    }
