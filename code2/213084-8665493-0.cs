    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace DAGShortestPath
    {
      class Arc
      {
        public Arc(int nextstate, float cost)
        {
          Nextstate = nextstate;
          Cost = cost;
        }
        public int Nextstate { get; set; }
        public float Cost { get; set; }
      };
      class State
      {
        public bool Final { get; set; }
        public List<Arc> Arcs { get; set; }
        public void AddArc(int nextstate, float cost)
        {
          if (Arcs == null)
            Arcs = new List<Arc>();
          Arcs.Add(new Arc(nextstate, cost));
        }
      }
      class Graph
      {
        List< State > _states  = new List< State >();
        int _start = -1;
        public void AddArc(int state, int nextstate, float cost)
        {
          while (_states.Count <= state)
            AddState();
          while (_states.Count <= nextstate)
            AddState();
          _states[state].AddArc(nextstate, cost);
        }
        public List<Arc> Arcs(int state)
        {
          return _states[state].Arcs;
        }
        public int AddState()
        {
          _states.Add(new State());
          return _states.Count - 1;
        }
    
        public bool IsFinal(int state)
        {
          return _states[state].Final;
        }
        public void SetFinal(int state)
        {
          _states[state].Final = true;
        }
        public void SetStart(int start)
        {
          _start = -1;
        }
        public int NumStates { get { return _states.Count; } }
        public void Print()
        {
          for (int i = 0; i < _states.Count; i++)
          { 
            var arcs = _states[i].Arcs;
            for (int j = 0; j < arcs.Count; j++)
            {
              var arc = arcs[j];          
              Console.WriteLine("{0}\t{1}\t{2}", i, j, arc.Cost);
            }
          }
        }
      }
      class Program
      {
        static List<int> ShortertPath(Graph graph)
        {
          float[] d = new float[graph.NumStates];
          int[] tb = new int[graph.NumStates];
          for (int i = 0; i < d.Length; i++)
          {
            d[i] = float.PositiveInfinity;
            tb[i] = -1;
          }      
          d[0] = 0.0f;
          float bestscore = float.PositiveInfinity;
          int beststate = -1;
          for (int i = 0; i < graph.NumStates; i++)
          {
            if (graph.Arcs(i) != null)
            {
              foreach (var arc in graph.Arcs(i))
              {
                if (arc.Nextstate < i)
                  throw new Exception("Graph is not topologically sorted");
                float e = d[i] + arc.Cost;
                if (e < d[arc.Nextstate])
                {
                  d[arc.Nextstate] = e;
                  tb[arc.Nextstate] = i;
                  if (graph.IsFinal(arc.Nextstate) && e < bestscore)
                  {
                    bestscore = e;
                    beststate = arc.Nextstate;
                  }
                }
              }
            }
          }
          //Traceback and recover the best final sequence
          if (bestscore == float.NegativeInfinity)
            throw new Exception("No valid terminal state found");
          Console.WriteLine("Best state {0} and score {1}", beststate, bestscore);
          List<int> best = new List<int>();
          while (beststate != -1)
          {
            best.Add(beststate);
            beststate = tb[beststate];
          }
          return best;
        }
        static void Main(string[] args)
        {
          Graph g = new Graph();
          String input = "ABBCAD";      
          for (int i = 0; i < input.Length - 1; i++)
            for (int j = i + 1; j < input.Length; j++)
            {
              //Modify this of different constraints on-the arcs
              //or graph topologies
              //if (input[i] < input[j])
              g.AddArc(i, j, 1.0f);
            }
          g.SetStart(0);
          //Modify this to make all states final for example
          //To compute longest sub-sequences and so on...
          g.SetFinal(g.NumStates - 1);
          var bestpath = ShortertPath(g);
          //Print the best state sequence in reverse
          foreach (var v in bestpath)
          {
            Console.WriteLine(v);        
          }
        }
      }
    }
