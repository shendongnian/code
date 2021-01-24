csharp
var sb = new System.Text.StringBuilder();
sb.AppendLine("City");
sb.AppendLine("\tMunich");
sb.AppendLine("\tLondon");
sb.AppendLine("Country");
sb.AppendLine("\tUK");
sb.AppendLine("\tIND");
Console.Write(sb);
or this:
csharp
var sb = new System.Text.StringBuilder();
sb.Append("City\n\tMunich\n\tLondon\nCountry\n\tUK\n\tIND\n");
Console.Write(sb);
a complete generic version does the trick: https://dotnetfiddle.net/qhjCsJ
csharp
using System;
using System.Collections.Generic;
using System.Text;
public class Node
{
	public string Text {get;set;}
	public IEnumerable<Node> Children{get;set;}=new List<Node>();
}
public class Program
{
	public static void Main()
	{
		var nodes=new []{
			new Node{
				Text="City",
				Children=new []{
					new Node{Text="Munich"},
					new Node{Text="London"},
				}
			},
			new Node{
				Text="Country",
				Children=new []{
					new Node{Text="UK"},
					new Node{Text="IND"},
				}
			}
		};
		
		var sb = new System.Text.StringBuilder();
		foreach(var node in nodes)
			RenderNode(sb, node);
		Console.Write(sb);
	}
	private static void RenderNode(StringBuilder sb, Node node, int indentationLevel = 0){
		sb.AppendLine(new String('\t', indentationLevel) + node.Text);
		foreach(var child in node.Children)
			RenderNode(sb, child, indentationLevel+1);
	}
}
