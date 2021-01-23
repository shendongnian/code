    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace Matrix
    {
        class Program
        {
            public static System.Data.DataTable CreateTeamTable()
            {
                DataTable team = new DataTable();
                team.TableName = "Team";
    
                team.Columns.Add(new DataColumn("TeamCode", typeof(int)));
                team.Columns.Add(new DataColumn("TeamName", typeof(string)));
    
                team.Rows.Add(new object[] { 0, "Ado Den Haag" });
                team.Rows.Add(new object[] { 1, "AZ" });
                team.Rows.Add(new object[] { 2, "FC Groningen" });
                team.Rows.Add(new object[] { 3, "FC Twente" });
                team.Rows.Add(new object[] { 4, "FC Utrecht" });
                team.Rows.Add(new object[] { 5, "Feyenoord" });
                team.Rows.Add(new object[] { 6, "Hercules Almelo" });
                team.Rows.Add(new object[] { 7, "NAC Breda" });
                team.Rows.Add(new object[] { 8, "PSV" });
                team.Rows.Add(new object[] { 9, "Roda JC" });
                team.Rows.Add(new object[] { 10, "SC Heerenveen" });
                team.Rows.Add(new object[] { 11, "Sparta Rotterdam" });
                team.Rows.Add(new object[] { 12, "Vitesse" });
                team.Rows.Add(new object[] { 13, "VVV-Venlo" });
                team.Rows.Add(new object[] { 14, "Willem II" });
                return team;
            }
            public static System.Data.DataTable CreateMatchTable()
            {
                DataTable matchTable = new DataTable();
                matchTable.TableName = "Match";
                matchTable.Columns.Add(new DataColumn("Host", typeof(int)));
                matchTable.Columns.Add(new DataColumn("Guest", typeof(int)));
                matchTable.Columns.Add(new DataColumn("Date", typeof(string)));
                matchTable.Columns.Add(new DataColumn("HostScor", typeof(int)));
                matchTable.Columns.Add(new DataColumn("GuestScor", typeof(int)));
    
                return matchTable;
            }
            public static List<MatrixItem> ToMatrix(System.Data.DataTable tbl)
            {
                var result = new List<MatrixItem>();
                int i = 0;
                foreach (System.Data.DataColumn column in tbl.Columns)
                {
    
                    int j = 0;
                    int x = 0;
                    foreach (System.Data.DataRow item in tbl.Rows)
                    {
    
                        var col = item[column].ToString();
                        if (i > 0)
                            col = string.Empty;
                        if (x == 0)
                        {
                            col = column.ColumnName;
                        }
                        if ((j == i) && (i > 0))
                            col = "*";
                        var m = new MatrixItem() { ColData = col, X = x, Y = i };
                        x += 15;
                        result.Add(m);
                        j++;
                    }
                    i++;
                }
                return result;
            }
            public static List<MatrixItem> CreateSample()
            {
                var list = new List<MatrixItem>();
    
                var countries = new string[] { "          ", "England   ", "Germany   ", "Holland   ", "Spain   ", "Germany   ", "Russia   ", "Japan" };
                for (int i = 0; i < countries.Length; i++)
                {
                    int x = 0;
                    int j = 0;
                    foreach (var item in countries)
                    {
                        var col = item;
                        if (i > 0)
                            col = string.Empty;
                        if (x == 0)
                        {
                            col = countries[i];
                        }
                        if ((j == i) && (i > 0))
                            col = "*";
                        var m = new MatrixItem() { ColData = col, X = x, Y = i };
                        x += item.Length;
                        list.Add(m);
                        j++;
                    }
                }
                return list;
            }
            public static void PrintMenu(System.Data.DataTable tblTeam)
            {
                Console.Clear();
                foreach (System.Data.DataRow item in tblTeam.Rows)
                {
                    Console.WriteLine(string.Format("{0} )- {1}", item["TeamCode"], item["TeamName"]));
                }
                Console.WriteLine("Press 1 to Enter Results");
                Console.WriteLine("Press 2 to show result table");
    
                Console.WriteLine("Enter Command Number");
            }
            public static void printMatrix(List<MatrixItem> list)
            {
                var j = 0;
                DosPrinter ds = new DosPrinter(900, 18);
                foreach (var item in list)
                {
                    ds.PrintXY(item.X, item.Y, item.ColData);
                }
                ds.Finilize();
            }
            public static int Readint()
            {
                string gcstr = Console.ReadLine();
                int gc = 0;
                while (!Int32.TryParse(gcstr, out gc))
                {
                    Console.WriteLine("Bad Value ( press x to exit app) re enter code : ");
                    gcstr = Console.ReadLine();
                }
                if (gcstr.ToLower() == "x")
                    return -1;
                return gc;
            }
            public static void GetResults(System.Data.DataTable results)
            {
                Console.WriteLine();
                Console.ReadLine();
                Console.Write("Enter Guest Code: ");
                int hc = Readint();
                Console.Write("Enter HostCode Code: ");
                int gc = Readint();
                Console.Write("Enter Match date: ");
                string dateStr = Console.ReadLine();
                Console.Write("Enter host score: ");
                int hs = Readint();
                Console.Write("Enter Guestscore: ");
                int gs = Readint();
                results.Rows.Add(new object[] { hc, gc, dateStr, hs, gs });
            }
            public static void ShowResult(System.Data.DataTable tblTeam,System.Data.DataTable tblMatches)
            {
                Console.Clear();
                var matrixList = new List<MatrixItem>();
                int i = 0;
                foreach (System.Data.DataRow horzRow in tblTeam.Rows)
                {
                    int x = 0;
                    int j = 0;
                    foreach (System.Data.DataRow vertRow in tblTeam.Rows)
                    {
                        string col = string.Empty;
                        if (i > 0 & j > 0)
                        {
                            var rs = tblMatches.Select(string.Format("(Host={0} and guest={1}) or (Host={1} and guest={0})", horzRow["TeamCode"], vertRow["TeamCode"]));
                            if (rs.Length > 0)
                                col = "*";
                        }
                        if (i == 0 & j == 0)
                        {
                            col = "        ";
                        }
                        if ((i == 0) && (j > 0))
                        {
                            col = vertRow["TeamName"].ToString();
                        }
                        if ((i > 0) && (j == 0))
                        {
                            col = horzRow["TeamName"].ToString();
                        }
    
                        var m = new MatrixItem() { ColData = col, X = x, Y = i };
                        x += 25;
                        matrixList.Add(m);
                        j++;
    
                    }
                    i++;
                }
                printMatrix( matrixList );
                Console.ReadKey();
            }
    
            static void Main(string[] args)
            {
                var teams = CreateTeamTable();
                var matches = CreateMatchTable();
                int x = 'a';
                while (x != 'x')
                {
                    PrintMenu(teams);
    
                    x = Console.Read();
                    if (x == '1')
                    {
                        GetResults(matches);
                    }
                    if (x == '2')
                    {
                        ShowResult(teams, matches);
                    }
                }
    
                Console.ReadKey();
            }
        }
    
        public class MatrixItem
        {
            public string ColData { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
    
        }
        public class DosPrinter
        {
            #region Fields
            private int width;
            private int height;
            private byte[,] canvas;
            private int baseX = 0;
            private int baseY = 0;
    
    
            #endregion
    
    
    
            #region Functionality
    
    
            public void PrintXY(int x, int y, string value)
            {
                int startx = baseX + x;// -value.Length;
                for (int i = 0; i < value.Length; i++)
                {
                    canvas[startx + i, baseY + y] = Convert.ToByte(value[i]);
                }
            }
            public void Finilize()
            {
                object k = 1;
                object l = 0;
                object lf = false;
                object ss = " ";
    
                try
                {
                    for (int i = 0; i < height; i++)
                    {
    
                        Array crt = Array.CreateInstance(typeof(byte), baseX + this.width);
                        string line = string.Empty;
                        for (int j = 0; j < baseX + width; j++)
                        {
                            crt.SetValue(canvas[j, i], j);
                            line += ((char)canvas[j, i]).ToString();
                        }
                        Console.WriteLine(line);
                        //vbPrinter.PrintBytes(ref crt, ref LineFeed);
                    }
                }
                catch { }
            }
            public void CleareBuffer()
            {
                InitCanvas();
            }
            public void InitCanvas()
            {
                canvas = new byte[baseX + width, baseY + height];
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        canvas[i, j] = 32;
                    }
                }
            }
            public string DrawLine(int len)
            {
                string line = string.Empty;
                for (int i = 0; i < len; i++)
                {
                    line += "-";
                }
                return line;
            }
            #endregion
    
            #region Constructor
            public DosPrinter(int width, int height)
            {
                this.width = baseX + width;
                this.height = baseY + height;
                InitCanvas();
            }
            #endregion
        }
    }
