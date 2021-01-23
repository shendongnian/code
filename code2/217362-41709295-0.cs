using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DeepListCopy_testingSome
{
class Program
{
static void Main(string[] args)
{
List<int>list1  = new List<int>();
List<int>list2 = new List<int>();
//populate list1
for (int i = 0; i < 20 ; i++)
{
list1.Add(1);
}
///////
Console.WriteLine("\n int in each list1 element is:\n");
///////
foreach(int i in list1) 
{
Console.WriteLine(" list1 elements: {0}", i);
list2.Add(1);
}
///////
Console.WriteLine("\n int in each list2 element is:\n");
///////
foreach(int i in list2)
{
Console.WriteLine(" list2 elements: {0}", i);
 }
/////// 
