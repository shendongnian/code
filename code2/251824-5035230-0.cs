    public class TestPrg
    {
        static void Main()
        {
            var expression = new RegexParser("a(b|c)*d").Parse();
            foreach (var item in expression.Generate())
            {
                Console.WriteLine(item);
            }
        }
    }
    public static class EnumerableExtensions
    {
        // Build a Cartesian product of a sequence of sequences
        // Code by Eric Lippert, copied from <http://blogs.msdn.com/b/ericlippert/archive/2010/06/28/computing-a-cartesian-product-with-linq.aspx>
        public static IEnumerable<IEnumerable<T>> CartesianProduct<T>(this IEnumerable<IEnumerable<T>> sequences)
        {
            IEnumerable<IEnumerable<T>> emptyProduct = new[] { Enumerable.Empty<T>() };
            return sequences.Aggregate(
                emptyProduct,
                (accumulator, sequence) =>
                from accseq in accumulator
                from item in sequence
                select accseq.Concat(new[] { item }));
        }
    }
    public class RegexParser
    {
        private const char EOF = '\x0000';
        private readonly string str;
        private char curr;
        private int pos;
        public RegexParser(string s)
        {
            str = s;
        }
        public RegExpression Parse()
        {
            pos = -1;
            Read();
            return ParseExpression();
        }
        private void Read()
        {
            ++pos;
            curr = pos < str.Length ? str[pos] : EOF;
        }
        private RegExpression ParseExpression()
        {
            var term = ParseTerm();
            if (curr == '|')
            {
                Read();
                var secondExpr = ParseExpression();
                return new Variants(term, secondExpr);
            }
            else
            {
                return term;
            }
        }
        private RegExpression ParseTerm()
        {
            var factor = ParseFactor();
            if (curr != '|' && curr != '+' && curr != '*' && curr != ')' && curr != EOF)
            {
                var secondTerm = ParseTerm();
                return new Concatenation(factor, secondTerm);
            }
            else
            {
                return factor;
            }
        }
        private RegExpression ParseFactor()
        {
            var element = ParseElement();
            if (curr == '*')
            {
                Read();
                return new Repeat(element);
            }
            else
            {
                return element;
            }
        }
        private RegExpression ParseElement()
        {
            switch (curr)
            {
                case '(':
                    Read();
                    var expr = ParseExpression();
                    if (curr != ')') throw new FormatException("Closing paren expected");
                    Read();
                    return expr;
                case '\\':
                    Read();
                    var escapedChar = curr;
                    Read();
                    return new Literal(escapedChar);
                default:
                    var literal = curr;
                    Read();
                    return new Literal(literal);
            }
        }
    }
    public abstract class RegExpression
    {
        protected static IEnumerable<RegExpression> Merge<T>(RegExpression head, RegExpression tail, Func<T, IEnumerable<RegExpression>> selector)
            where T : RegExpression
        {
            var other = tail as T;
            if (other != null)
            {
                return new[] { head }.Concat(selector(other));
            }
            else
            {
                return new[] { head, tail };
            }
        }
        public abstract IEnumerable<string> Generate();
    }
    public class Variants : RegExpression
    {
        public IEnumerable<RegExpression> Subexpressions { get; private set; }
        public Variants(RegExpression term, RegExpression rest)
        {
            Subexpressions = Merge<Variants>(term, rest, c => c.Subexpressions);
        }
        public override IEnumerable<string> Generate()
        {
            return Subexpressions.SelectMany(sub => sub.Generate());
        }
    }
    public class Concatenation : RegExpression
    {
        public IEnumerable<RegExpression> Subexpressions { get; private set; }
        public Concatenation(RegExpression factor, RegExpression rest)
        {
            Subexpressions = Merge<Concatenation>(factor, rest, c => c.Subexpressions);
        }
        public override IEnumerable<string> Generate()
        {
            foreach (var variant in Subexpressions.Select(sub => sub.Generate()).CartesianProduct())
            {
                var builder = new StringBuilder();
                foreach (var item in variant) builder.Append(item);
                yield return builder.ToString();
            }
        }
    }
    public class Repeat : RegExpression
    {
        public RegExpression Expr { get; private set; }
        public Repeat(RegExpression expr)
        {
            Expr = expr;
        }
        public override IEnumerable<string> Generate()
        {
            foreach (var subexpr in Expr.Generate())
            {
                for (int cnt = 0; cnt < 5; ++cnt)
                {
                    var builder = new StringBuilder(subexpr.Length * cnt);
                    for (int i = 0; i < cnt; ++i) builder.Append(subexpr);
                    yield return builder.ToString();
                }
            }
        }
    }
    public class Literal : RegExpression
    {
        public char Ch { get; private set; }
        public Literal(char c)
        {
            Ch = c;
        }
        public override IEnumerable<string> Generate()
        {
            yield return new string(Ch, 1);
        }
    }
