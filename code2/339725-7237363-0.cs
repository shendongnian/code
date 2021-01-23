        static void Main()
        {
            LineBuffers lb = new LineBuffers(80 / 3);
            lb.Write(0, "-_ 1234567890");
            Console.WriteLine(String.Join(Environment.NewLine, lb.Lines.ToArray()));
            Console.WriteLine();
            Console.WriteLine(lb.ReadLine());
            lb.Clear();
            lb.Write(0, "abcdefghijklm");
            Console.WriteLine(String.Join(Environment.NewLine, lb.Lines.ToArray()));
            Console.WriteLine();
            Console.WriteLine(lb.ReadLine());
            lb.Clear();
            lb.Write(0, "nopqrstuvwxyz");
            Console.WriteLine(String.Join(Environment.NewLine, lb.Lines.ToArray()));
            Console.WriteLine();
            Console.WriteLine(lb.ReadLine());
            lb = new LineBuffers(" _     _  _  _ ", "|_| _ |  |_ |_|", @"|\ |_||_-|_ |\ ");
            Console.WriteLine(lb.ReadLine());
        }
        public class LineBuffers
        {
            private static string Characters = " -0123456789_abcdefghijklmnopqrstuvwxyz";
            private static readonly string[] Format =
                (
                @".   .   . _ .   . _ . _ .   . _ . _ . _ . _ . _ .   . _ .   . _ .   . _ . _ . _ .   . _ .  _.   .   .   .   .   . _ . _ . _ . _ .___.   .   .   .   .   .__ ." + "\n" +
                @".   . _ .| |.  |. _|. _|.|_|.|_ .|_ .  |.|_|.|_|.   .|_|.|_ .|  . _|.|_ .|_ .|  .|_|. | .  |.|/ .|  .|\|.|\|. _ .|_|.|_|.|_|./_ . | .| |.| |.|||. \/. \/. / ." + "\n" +
                @".   .   .|_|.  |.|_ . _|.  |. _|.|_|.  |.|_|. _|.___.| |.|_|.|_ .|_|.|_ .|  .|_-.| |. | . _|.|\ .|_ .|||.| |.|_|.|  .  |.|\ . _/. | .|_|.|/ .|/|. /\. | ./_ ."
                ).Split('\n');
            private readonly char[][] _lines;
            public LineBuffers(int charWidth)
            {
                _lines = new char[3][] {new char[charWidth*3], new char[charWidth*3], new char[charWidth*3]};
                Clear();
            }
            public LineBuffers(string line1, string line2, string line3) 
                : this(line1.ToCharArray(), line2.ToCharArray(), line3.ToCharArray()) { }
            public LineBuffers(char[] line1, char[] line2, char[] line3)
            {
                if (line1 == null || line2 == null || line3 == null 
                    || line1.Length != line2.Length || line2.Length != line3.Length)
                    throw new ArgumentException();
                _lines = new char[3][] {
                    line1, line2, line3
                };
            }
            public int Count { get { return _lines[0].Length / 3; } }
            public IEnumerable<string> Lines { get { return _lines.Select(chars => new String(chars)); } }
            public void Clear()
            {
                for (int i = 0; i < Count; i++)
                    Write(i, ' ');
            }
            public void Write(int position, IEnumerable<Char> character)
            { foreach (char ch in character) Write(position++, ch); }
            public void Write(int position, Char character)
            {
                int charIx = Characters.IndexOf(Char.ToLower(character));
                if (charIx < 0)
                    throw new ArgumentOutOfRangeException("character");
                if (position >= Count)
                    throw new ArgumentOutOfRangeException("position");
                int offset = charIx*4 + 1;
                for(int line=0; line <3; line++)
                    Array.Copy(Format[line].ToCharArray(offset, 3), 0, _lines[line], position * 3, 3);
            }
            public Char Read(int position)
            {
                if (position >= Count)
                    throw new ArgumentOutOfRangeException("position");
                IEnumerable<int> found = Find(Format[0], _lines[0], position*3)
                    .Intersect(Find(Format[1], _lines[1], position*3))
                    .Intersect(Find(Format[2], _lines[2], position*3));
                int[] result = found.ToArray();
                if (result.Length != 1)
                    throw new FormatException();
                return Characters[result[0]];
            }
            IEnumerable<int> Find(string findIn, char[] text, int charIx)
            {
                for(int i=1; i < findIn.Length; i += 4)
                {
                    if (findIn[i] == text[charIx] && findIn[i + 1] == text[charIx + 1] && findIn[i + 2] == text[charIx + 2])
                        yield return i/4;
                }
            }
            public string ReadLine()
            {
                char[] text = new char[Count];
                for (int ix = 0; ix < Count; ix++)
                    text[ix] = Read(ix);
                return new String(text);
            }
        }
