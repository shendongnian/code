    using System;
    using System.IO;
    namespace ConsoleApp2
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (StreamReader sr = new StreamReader(File.Open(@"z:\data.txt", FileMode.Open)))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        if (s.Length != 185)
                        {
                            Console.WriteLine("Wrong length record");
                        }
                        else
                        {
                            Order c = new Order();
                            c.NUM = s.Substring(0, 6);
                            c.FLAG = s.Substring(6, 2);
                            c.IP = s.Substring(8, 12);
                            for (int i = 0, idx = 20; i < 5; i++, idx += 33)
                            {
                                c.AN_AREA[i] = new Order.COST();
                                c.AN_AREA[i].TYPE = s.Substring(idx, 2);
                                c.AN_AREA[i].ISO = s.Substring(idx + 2, 3);
                                c.AN_AREA[i].CODE = s.Substring(idx + 5, 6);
                                c.AN_AREA[i].IND_X = s.Substring(idx + 11, 2);
                                c.AN_AREA[i].AMT = s.Substring(idx + 13, 20);
                            }
                            Console.WriteLine(c.NUM);
                            Console.WriteLine(c.FLAG);
                            Console.WriteLine(c.IP);
                            for (int i = 0; i < 5; i++)
                            {
                                Console.WriteLine(c.AN_AREA[i].TYPE);
                                Console.WriteLine(c.AN_AREA[i].ISO);
                                Console.WriteLine(c.AN_AREA[i].CODE);
                                Console.WriteLine(c.AN_AREA[i].IND_X);
                                Console.WriteLine(c.AN_AREA[i].AMT);
                            }
                        }
                        Console.WriteLine("--------------------");
                    }
                }
                Console.ReadLine();
            }
        }
        public class Order
        {
            public string NUM;       //05  NUM PIC X(6)
            public string FLAG;      //05  FLAG PIC XX
            public string IP;        //05  IP PIC X(12)
                                     //05  AN-AREA.
            public COST[] AN_AREA = new COST[5]; //10  COST OCCURS 5 TIMES.
            public class COST
            {
                public string TYPE;  //15 TYPE PIC XX.
                public string ISO;   //15 ISO PIC XXX.
                public string CODE;  //15 CODE PIC X(6).
                public string IND_X; //15 IND-X
                                     //    PIC XX.
                                     //15 IND
                                     //      REDEFINES
                                     //      IND-X
                                     //      PIC 99.
                public string AMT;   //15 AMT PIC X(20).
            }
        }
    }
