using System.Threading;
namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            Thread.Sleep(2000);
            SetupBigThings();
            Thread.Sleep(2000);
            string big = new string('a', 1000000000);
            while (true)
            {
                Thread.Sleep(2000);
            }
        }
        static void SetupBigThings()
        {
            Thread.Sleep(1000);
            BigThing x = new BigThing('x');
            Thread.Sleep(1000);
            BigThing y = new BigThing('y') { OtherBigThing = x };
            x.OtherBigThing = y;
            Thread.Sleep(1000);
        }
    }
    class BigThing
    {
        public BigThing OtherBigThing { get; set; }
        private string big;
        public BigThing(char c)
        {
            big = new string(c, 750000000);
        }
    }
}
Looking at the code we should see a memory spike at 3 seconds, then again at 4 seconds.. After 5 seconds the big objects are out of scope and maybe they will be GC'd at around 7 seconds when the next large object is created
And pretty much that's what the graph shows:
[![enter image description here][1]][1]
I thus posit that the GC can indeed collect objects whose only reference is to each other. It's probably not so naive as to simply say "which objects have 0 references?", but instead will chase out reference paths, and any objects that refer only to another node already being considered for GC are also considered GC'able. I'm no expert on the inner workings of the GC though
  [1]: https://i.stack.imgur.com/yrzcP.png
