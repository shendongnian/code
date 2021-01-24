using System.Linq;
namespace StackOverflow
{
    public class ArrayUtils
    {
        public int GetMax(int[] arr)
        {
            return arr.Max();
        }
        public int GetMin(int[] arr)
        {
            return arr.Min();
        }
        public int[] GetReverse(int[] arr)
        {
            return arr.Reverse().ToArray();
        }
        public int[] SquareValues(int[] arr)
        {
            return arr.Select(x => x * x).ToArray();
        }
    }
}
