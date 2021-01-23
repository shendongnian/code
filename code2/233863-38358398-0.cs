    int[,] Adjacency = new int[6, 6] {
                { 0,1,0,1,0,0 },
                { 0,0,1,1,0,0 },
                { 0,0,0,0,1,0 },
                { 0,1,0,0,0,0 },
                { 0,0,0,1,0,1 },
                { 0,1,1,0,0,0 }};
        public void Start()
        {
            List<List<int>> Out = new List<List<int>>();
            FindAllCycles(new List<int>(), new List<int>(), Out, 0);
            Console.WriteLine("");
            foreach (List<int> CurrCycle in Out)
            {
                string CurrString = "";
                foreach (int Currint in CurrCycle) CurrString += Currint + ", ";
                Console.WriteLine(CurrString);
            }
        }
        private void FindAllCycles(List<int> GloballyVisited, List<int> CurrentCycleVisited, List<List<int>> Cycles, int CurrNode)
        {
            GloballyVisited.Add(CurrNode);
            CurrentCycleVisited.Add(CurrNode);
            for (int OutEdgeCnt = 0; OutEdgeCnt < Adjacency.GetLength(0); OutEdgeCnt++)
            {
                if (Adjacency[CurrNode, OutEdgeCnt] == 1)//CurrNode Is connected with OutEdgeCnt
                {
                    if (CurrentCycleVisited.Contains(OutEdgeCnt))
                    {
                        int StartIndex = CurrentCycleVisited.IndexOf(OutEdgeCnt);
                        int EndIndex = CurrentCycleVisited.IndexOf(CurrNode);
                        Cycles.Add(CurrentCycleVisited.GetRange(StartIndex, EndIndex - StartIndex + 1));
                    }
                    else if (!GloballyVisited.Contains(OutEdgeCnt))
                    {
                        FindAllCycles(GloballyVisited, new List<int>(CurrentCycleVisited), Cycles, OutEdgeCnt);
                    }
                }
            }
        }
