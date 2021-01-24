    void Main()
    {
        using (var file = File.OpenText(@"d:\temp\test.json"))
        using (var fix = new MyFalseFixingTextReader(file))
        {
            var reader = new JsonTextReader(fix);
            var serializer = new JsonSerializer();
            serializer.Deserialize<Test>(reader).Dump();
        }
    }
    
    public class MyFalseFixingTextReader : TextReader
    {
        private readonly TextReader _Reader;
        private readonly StringBuilder _Buffer = new StringBuilder(32768);
    
        public MyFalseFixingTextReader(TextReader reader) => _Reader = reader;
    
        public override void Close()
        {
            _Reader.Close();
            base.Close();
        }
    
        public override int Read(char[] buffer, int index, int count)
        {
            TryFillBuffer(count);
    
            int amountToCopy = Math.Min(_Buffer.Length, count);
            _Buffer.CopyTo(0, buffer, index, amountToCopy);
            _Buffer.Remove(0, amountToCopy);
            return amountToCopy;
        }
        
        private (bool more, char c) TryReadChar()
        {
            int i = _Reader.Read();
            if (i < 0)
                return (false, default);
            return (true, (char)i);
        }
    
        private (bool more, char c) TryPeekChar()
        {
            int i = _Reader.Peek();
            if (i < 0)
                return (false, default);
            return (true, (char)i);
        }
    
        private void TryFillBuffer(int count)
        {
            if (_Buffer.Length >= count)
                return;
    
            while (_Buffer.Length < count)
            {
                var (more, c) = TryPeekChar();
                if (!more)
                    break;
                switch (c)
                {
                    case '{':
                    case '}':
                    case '[':
                    case ']':
                    case '\r':
                    case '\n':
                    case ' ':
                    case '\t':
                    case ':':
                    case ',':
                        _Reader.Read();
                        _Buffer.Append(c);
                        break;
    
                    case '"':
                        _Buffer.Append(GrabString());
                        break;
                        
                    case char letter when char.IsLetter(letter):
                        var identifier = GrabIdentifier();
                        _Buffer.Append(ReplaceFaultyIdentifiers(identifier));
                        break;
                        
                    case char startOfNumber when startOfNumber == '-' || (startOfNumber >= '0' && startOfNumber <= '9'):
                        _Buffer.Append(GrabNumber());
                        break;
    
                    default:
                        throw new InvalidOperationException($"Unable to cope with character '{c}' (0x{((int)c).ToString("x2")})");
                }
            }
        }
    
        private string ReplaceFaultyIdentifiers(string identifier)
        {
            switch (identifier)
            {
                case "False":
                    return "false";
                    
                case "True":
                    return "true";
                    
                case "Null":
                    return "null";
                    
                default:
                    return identifier;
            }
        }
    
        private string GrabNumber()
        {
            throw new NotImplementedException("Left as an excercise");
            // See https://www.json.org/ for the syntax
        }
    
        private string GrabIdentifier()
        {
            var result = new StringBuilder();
            while (true)
            {
                int i = _Reader.Peek();
                if (i < 0)
                    break;
    
                char c = (char)i;
                if (char.IsLetter(c))
                {
                    _Reader.Read();
                    result.Append(c);
                }
                else
                    break;
            }
            return result.ToString();
        }
    
        private string GrabString()
        {
            _Reader.Read();
            
            var result = new StringBuilder();
            result.Append('"');
            
            while (true)
            {
                var (more, c) = TryReadChar();
                if (!more)
                    return result.ToString();
    
                switch (c)
                {
                    case '"':
                        result.Append(c);
                        return result.ToString();
    
                    case '\\':
                        result.Append(c);
                        (more, c) = TryReadChar();
                        if (!more)
                            return result.ToString();
    
                        switch (c)
                        {
                            case 'u':
                                result.Append(c);
                                for (int index = 1; index <= 4; index++)
                                {
                                    (more, c) = TryReadChar();
                                    if (!more)
                                        return result.ToString();
                                    result.Append(c);
                                }
                                break;
    
                            default:
                                result.Append(c);
                                break;
                        }
                        break;
    
                    default:
                        result.Append(c);
                        break;
                }
            }
        }
    }
    
    public class Test
    {
        public bool False1 { get; set; }
        public bool False2 { get; set; }
        public bool False3 { get; set; }
    }
