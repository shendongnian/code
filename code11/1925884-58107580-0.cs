    class Program
    {
        static void Main(string[] args)
        {
            var yaml = new YamlParser("data.yaml");
            Debug.WriteLine(string.Join(Environment.NewLine, yaml.Head));
            // title: Welcome post
            // tags: [tech]
            // enabled: true
            Debug.WriteLine(string.Join(Environment.NewLine, yaml.Intro));
            // This is the post intro.
            Debug.WriteLine(string.Join(Environment.NewLine, yaml.Body));
            // This is the post body.
        }
    }
    public enum YamlSection
    {
        Start,
        Header,
        Into,
        Body,
        Finished
    }
    public class YamlParser
    {
        public YamlParser(string file)
            : this(System.IO.File.OpenText(file))
        {  }
        public YamlParser(StreamReader reader)
        {
            Head = new List<string>();
            Intro = new List<string>();
            Body = new List<string>();
            var section = YamlSection.Start;
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                if (line.StartsWith("---") && section == YamlSection.Start)
                {
                    section = YamlSection.Header;
                }
                else if (line.StartsWith("---") && section == YamlSection.Header)
                {
                    section = YamlSection.Into;
                }
                else if (line.StartsWith("***"))
                {
                    section =  YamlSection.Body;
                }
                else
                {
                    switch (section)
                    {
                        case YamlSection.Header:
                            Head.Add(line);
                            break;
                        case YamlSection.Into:
                            Intro.Add(line);
                            break;
                        case YamlSection.Body:
                            Body.Add(line);
                            break;
                        default:
                            throw new NotSupportedException();
                    }
                }
            }
            section = YamlSection.Finished;
        }
        public List<string> Head { get; }  
        public List<string> Intro { get; } 
        public List<string> Body { get; }  
    }
