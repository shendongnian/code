using System;
using System.Linq;
using System.Xml.Linq;
namespace ConsoleApp1
{
    class Program
    {
        public static string xml = @"<topLevel><bus>
    <port isCorrectNode='no'>
        <req>
            <item>
            </item> 
        </req>
        <req mode='read'>
            <item>
            </item> 
        </req>
    </port>
    <port isCorrectNode='yes'>
        <req mode='read'>
            <item>
            </item> 
        </req>
        <req>
            <item>
            </item> 
        </req>
    </port>
</bus>
<bus>
</bus>
</topLevel>";
        static void Main(string[] args)
        {
            XElement root = XElement.Parse(xml);
            var found = root.Elements("bus").Elements("port")
                .Where(x => x.Elements("req").Any(y => y.Attribute("mode") != null && y.Attribute("mode").Value.Contains("read")))
                .Last();
            var isThisTheCorrectNode = found.Attribute("isCorrectNode").Value;
            Console.WriteLine(isThisTheCorrectNode);
        }
    }
}
will write `yes`
