    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;
    // using ....Util; // for .ForEach extension method (google)
    
    namespace Reporting.Dot
    {
        // ReSharper disable InconsistentNaming
        // ReSharper disable RedundantIfElseBlock
        public class Node
        {
            public string id;
            public string label;
            public string shape;
            public string other;
            public ICollection<string> terminals = new List<string>();
    
            #region Equality
            public override bool Equals(object obj)
            {
                if (obj == null)
                    return false;
                if (ReferenceEquals(this, obj))
                    return true;
                if (obj.GetType() != typeof(Node))
                    return false;
                return id == ((Node)obj).id;
            }
    
            public override int GetHashCode()
            { unchecked { return (id != null ? id.GetHashCode() : 0); } }
            #endregion
    
            public string ToString(bool declaration)
            {
                if (!declaration)
                    return id;
                var attributes = new List<string> 
    				{ string.Format(@"label=""{0}"",shape={1}", BuildLabel(), shape?? "box"), };
    			if (!string.IsNullOrEmpty(other))
    				attributes.Add(other);
    				
                return string.Format(@"{0}[{1}];", id, string.Join(",", attributes.ToArray()));
            }
    
            private string BuildLabel()
            {
                if (terminals.Count > 0)
                {
                    var sb = new StringBuilder();
                    sb.AppendFormat("{{{0}", label);
                    terminals./*Reverse().*/ForEach(t => sb.AppendFormat("|<{0}>{1}", (UInt32)t.GetHashCode(), t));
                    sb.Append("}");
    
                    return sb.ToString();
                }
                else
                    return label;
            }
    
            public override string ToString()
            {
                return ToString(true);
            }
    
        }
    
        public class Endpoint
        {
            public Node node;
            public string terminal;
    
            public override string ToString()
            {
                if (String.IsNullOrEmpty(terminal))
                    return node.ToString(false);
                else
                    return string.Format("{0}:{1}", node.id, (UInt32)terminal.GetHashCode());
            }
        }
    
        public class Edge
        {
            public Endpoint source;
            public Endpoint target;
            public string label;
            public string style;
            public string color;
    
            #region Equality
            public override bool Equals(object obj)
            {
                if (obj == null)
                    return false;
                if (ReferenceEquals(this, obj))
                    return true;
                if (obj.GetType() != typeof(Edge))
                    return false;
                return source == ((Edge)obj).source && target == ((Edge)obj).target && label == ((Edge)obj).label;
            }
    
            public override int GetHashCode()
            {
                unchecked { return (source != null ? source.GetHashCode() : 0) ^ (target != null ? target.GetHashCode() : 0) ^ (label != null ? label.GetHashCode() : 0); }
            }
            #endregion
    
            public override string ToString()
            {
                return string.Format(@"{{ {0} -> {1} [label=""{2}"", style=""{3}"", color=""{4}""]; }}", source, target, label ?? "", style ?? "solid", color ?? "black");
            }
    
        }
    
        public class Digraph
        {
            public string name;
            public string label;
            public string rankdir;
            public string declarations;
    
            public readonly ICollection<Node> nodes = new HashSet<Node>();
            public readonly ICollection<Edge> edges = new HashSet<Edge>();
    
            public readonly IDictionary<string, Digraph> subgraphs = new Dictionary<string, Digraph>();
    
            public Digraph(string name, IEnumerable<Node> nodes, IEnumerable<Edge> edges)
            {
                this.name = name;
                if (nodes != null) foreach (var node in nodes) this.nodes.Add(node);
                if (edges != null) foreach (var edge in edges) this.edges.Add(edge);
            }
    
            public override string ToString()
            {
                return ToString(false);
            }
    
            public string ToString(bool main)
            {
                return String.Format(@"
                    {5} {0} {{
                    	label=""{1}"";
                    	{6} // rankdir
    
                    	//nodes
                    	{3}
                    	//subgraphs
                    	{2}
                    	//edges
                    	{4}
                    }}
            	",
                    (main ? "" : "cluster") + name.Replace(".", "").Replace(" ", ""),
                    label ?? name,
                    subgraphs.Textify(),
                    nodes.Textify(),
                    edges.Textify(),
                    main ? "digraph" : "subgraph",
                    main ? "rankdir=" + (rankdir ?? "TB") + ";" : "");
            }
    
            internal IEnumerable<Node> AllNodes
            {
                get { return nodes.Union(subgraphs.Values.SelectMany(g => g.AllNodes));  }
            }
    
            internal Node Find(string id)
            {
                return AllNodes.FirstOrDefault(n => id == n.id);
            }
        }
    
        /*
         * simple DWIM standing for ToString() on collections
         */
        internal static class Textifiers
        {
            internal static StringBuilder Textify<T, Y>(this IDictionary<T, Y> table)
            { return Textify(table.Values); }
    
            internal static StringBuilder Textify<T>(this IEnumerable<T> items)
            {
                return items.Aggregate(new StringBuilder(),
                    (a, i) => a.Append(i.ToString()));
            }
        }
    
    }
