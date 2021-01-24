        public void Solve()
        {
            string input = 
                                    @"55
                                    94 48
                                   95 30 96
                                 77 71 26 67
                                97 13 76 38 45
                              07 36 79 16 37 68
                             48 07 09 18 70 26 06
                           18 72 79 46 59 79 29 90
                          20 76 87 11 32 07 07 49 18
                        27 83 58 35 71 11 25 57 29 85
                       14 64 36 96 27 11 58 56 92 18 55
                     02 90 03 60 48 49 41 46 33 36 47 23
                    92 50 48 02 36 59 42 79 72 20 82 77 42
                  56 78 38 80 39 75 02 71 66 66 01 03 55 72
                 44 25 67 84 71 67 11 61 40 57 58 89 40 56 36
               85 32 25 85 57 48 84 35 47 62 17 01 01 99 89 52
              06 71 28 75 94 48 37 10 23 51 06 48 53 18 74 98 15
            27 02 92 23 08 71 76 84 15 52 92 63 81 10 44 10 69 93";
            var tree = input.Split('\n')
                .Select(line => line.Trim()
                    .Split(' ')
                    .Select(s => new Node(int.Parse(s.Trim())))
                    .ToArray())
                .ToArray();
            for (var i = 0; i < tree.Length-1; i++)
            {
                for (var j = 0; j < tree[i].Length; j++)
                {
                    tree[i][j].Descendants.Add(tree[i + 1][j]);
                    tree[i][j].Descendants.Add(tree[i + 1][j+1]);
                }
            }
            var root = tree[0][0];
            int maxSum = 0;
            DepthFirstSearch(tree[0][0],  ImmutableList<Node>.Empty.Add(root), 0, ref maxSum);
        }
        private void DepthFirstSearch(Node root, ImmutableList<Node> path, int runningSum, ref int maxSum)
        {
            CheckBaseCase(root, path, ref maxSum);
            foreach(var node in root.Descendants)
            {
                runningSum += node.Value;
                DepthFirstSearch(node, path.Add(node), runningSum, ref maxSum);
            }
        }
        private void CheckBaseCase(Node root, ImmutableList<Node> path, ref int maxSum)
        {
            // Fill me in!
        }
       [DebuggerDisplay("Value = {Value}, DescendantCount={Descendants.Count}")]
       class Node
       {
           public Node(int value)
           {
               Value = value;
           }
           public int Value{ get; }
           public List<Node> Descendants { get; } = new List<Node>();
       }
