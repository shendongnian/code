    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApp8
    {
        /// <summary>
        /// The Node class
        /// </summary>
        public class Node
        {
            public int Level { get; set; }
            public List<int> Parents { get; set; }
            public int Element { get; set; }
        }
    
        /// <summary>
        /// The Triangle class Representation
        /// </summary>
        public class Triangle
        {
            /// <summary>
            /// The triangle root
            /// </summary>
            public int Root { get; set; }
    
            /// <summary>
            /// The Node per each level of depth
            /// </summary>
            public List<List<Node>> LevelNodes { get; set; }
    
            /// <summary>
            /// Build the triangle structure
            /// </summary>
            public void BuildTriangle()
            {
                List<Node> nodeLevelList = new List<Node>();
                bool carryOn = true;
    
    
    
                //****************************************************
                //Create Root and second level
                Console.WriteLine("Add Tree Root");
                Root = Convert.ToInt32(Console.ReadLine());
                LevelNodes = new List<List<Node>>();
    
                //set the first node to have the root has parent
                Node myNode = new Node
                {
                    Parents = new List<int> { Root }
                };
    
                Console.WriteLine("Add Left Child");
                myNode.Element = Convert.ToInt32(Console.ReadLine());
                myNode.Level = 2;
                //add the node
                nodeLevelList.Add(myNode);
    
                myNode = new Node
                {
                    Parents = new List<int> { Root }
                };
                Console.WriteLine("Add Right Child");
                myNode.Element = Convert.ToInt32(Console.ReadLine());
                myNode.Level = 2;
                //add the node
                nodeLevelList.Add(myNode);
                LevelNodes.Add(nodeLevelList);
    
                //****************************************************
    
                Console.Clear();
    
                //****************************************************
                // Build the rest of the triangle data structure
                while (carryOn)
                {
                    nodeLevelList = new List<Node>();
                    //take all the nodes on last level entered
                    var nodes = LevelNodes.Last().ToList();
    
                    bool firstElement = true;
    
    
                    foreach (var node in nodes)
                    {
                        myNode = new Node();
    
                        if (firstElement)
                        {
                            Console.WriteLine("Add Left Child for parent : {0}", node.Element);
                            myNode.Element = Convert.ToInt32(Console.ReadLine());
                            myNode.Parents = new List<int> { node.Element };
                            myNode.Level = node.Level + 1;
                            //add the node
                            nodeLevelList.Add(myNode);
    
                            firstElement = false;
                        }
                        else
                        {
                            var temp = nodeLevelList.Last();
                            temp.Parents.Add(node.Element);
                        }
    
                        //re-initialise node
                        myNode = new Node();
                        Console.WriteLine("Add Right Child for parent : {0}", node.Element);
                        myNode.Element = Convert.ToInt32(Console.ReadLine());
                        myNode.Parents = new List<int> { node.Element };
                        myNode.Level = node.Level + 1;
                        //add the node
                        nodeLevelList.Add(myNode);
    
                    }
    
                    LevelNodes.Add(nodeLevelList);
                    Console.Clear();
    
                    Console.WriteLine("Do you wish to continue adding elements ? Y or N");
                    carryOn = Console.ReadLine()?.ToLower() == "y";
                }
            }
    
    
            public int GetLargetPathSum()
            {
                int result = Root;
                int selectedValue = Root;
                Node nodeSelected = new Node();
    
                foreach (List<Node> levelNode in LevelNodes)
                {
                    int maxValue = 0;
    
                    foreach (Node node in levelNode.Where(x=> x.Parents.Contains(selectedValue)).Select(x=> x).ToList())
                    {
                        if (node.Element > maxValue)
                        {
                            maxValue = node.Element;
                            nodeSelected = node;
                        }
                    }
    
                    result += maxValue;
                    selectedValue = maxValue;
                }
    
                return result;
            }
        }
    
        public class Program
        {
            static void Main(string[] args)
            {
                Triangle triangle = new Triangle();
                triangle.BuildTriangle();
    
                Console.WriteLine(triangle.GetLargetPathSum());
                Console.ReadLine();
    
            }
        }
    }
 
