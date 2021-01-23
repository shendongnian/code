    using System.Collections.Generic;
    namespace q7922337
    {
        static class Program
        {
            static void Main(string[] args)
            {
                var result1 = Match.ParseList<TagsGroup>("[code]This is a successful match.[/code]");
                var result2 = Match.ParseList<TagsGroup>("[code]This is an [ unsuccessful match.[/code]");
                var result3 = Match.ParseList<TagsGroup>("[code]This is also an [unsuccessful] match.[/code]");
                var result4 = Match.ParseList<TagsGroup>(@"
                            [code]  
                                some code  
                                [b]some text [url=http://www.google.com]some link[/url][/b]  
                            [/code]");
            }
            class ParseContext
            {
                public string Source { get; set; }
                public int Position { get; set; }
            }
            abstract class Match
            {
                public override string ToString()
                {
                    return this.Text;
                }
                public string Source { get; set; }
                public int Start { get; set; }
                public int Length { get; set; }
                public string Text { get { return this.Source.Substring(this.Start, this.Length); } }
                protected abstract bool ParseInternal(ParseContext context);
                public bool Parse(ParseContext context)
                {
                    var result = this.ParseInternal(context);
                    this.Length = context.Position - this.Start;
                    return result;
                }
                public bool MarkBeginAndParse(ParseContext context)
                {
                    this.Start = context.Position;
                    var result = this.ParseInternal(context);
                    this.Length = context.Position - this.Start;
                    return result;
                }
                public static List<T> ParseList<T>(string source)
                    where T : Match, new()
                {
                    var context = new ParseContext
                    {
                        Position = 0,
                        Source = source
                    };
                    var result = new List<T>();
                    while (true)
                    {
                        var item = new T { Source = source, Start = context.Position };
                        if (!item.Parse(context))
                            break;
                        result.Add(item);
                    }
                    return result;
                }
                public static T ParseSingle<T>(string source)
                    where T : Match, new()
                {
                    var context = new ParseContext
                    {
                        Position = 0,
                        Source = source
                    };
                    var result = new T { Source = source, Start = context.Position };
                    if (result.Parse(context))
                        return result;
                    return null;
                }
                protected List<T> ReadList<T>(ParseContext context)
                    where T : Match, new()
                {
                    var result = new List<T>();
                    while (true)
                    {
                        var item = new T { Source = this.Source, Start = context.Position };
                        if (!item.Parse(context))
                            break;
                        result.Add(item);
                    }
                    return result;
                }
                protected T ReadSingle<T>(ParseContext context)
                    where T : Match, new()
                {
                    var result = new T { Source = this.Source, Start = context.Position };
                    if (result.Parse(context))
                        return result;
                    return null;
                }
                protected int ReadSpaces(ParseContext context)
                {
                    int startPos = context.Position;
                    int cnt = 0;
                    while (true)
                    {
                        if (startPos + cnt >= context.Source.Length)
                            break;
                        if (!char.IsWhiteSpace(context.Source[context.Position + cnt]))
                            break;
                        cnt++;
                    }
                    context.Position = startPos + cnt;
                    return cnt;
                }
                protected bool ReadChar(ParseContext context, char p)
                {
                    int startPos = context.Position;
                    if (startPos >= context.Source.Length)
                        return false;
                    if (context.Source[startPos] == p)
                    {
                        context.Position = startPos + 1;
                        return true;
                    }
                    return false;
                }
            }
            class Tag : Match
            {
                protected override bool ParseInternal(ParseContext context)
                {
                    int startPos = context.Position;
                    if (!this.ReadChar(context, '['))
                        return false;
                    this.ReadSpaces(context);
                    if (this.ReadChar(context, '/'))
                        this.IsEndTag = true;
                    this.ReadSpaces(context);
                    var validName = this.ReadValidName(context);
                    if (validName != null)
                        this.Name = validName;
                    this.ReadSpaces(context);
                    if (this.ReadChar(context, ']'))
                        return true;
                    context.Position = startPos;
                    return false;
                }
                protected string ReadValidName(ParseContext context)
                {
                    int startPos = context.Position;
                    int endPos = startPos;
                    while (char.IsLetter(context.Source[endPos]))
                        endPos++;
                    if (endPos == startPos) return null;
                    context.Position = endPos;
                    return context.Source.Substring(startPos, endPos - startPos);
                }
                public bool IsEndTag { get; set; }
                public string Name { get; set; }
            }
            class TagsGroup : Match
            {
                public TagsGroup()
                {
                }
                protected TagsGroup(Tag openTag)
                {
                    this.Start = openTag.Start;
                    this.Source = openTag.Source;
                    this.OpenTag = openTag;
                }
                protected override bool ParseInternal(ParseContext context)
                {
                    var startPos = context.Position;
                    if (this.OpenTag == null)
                    {
                        this.ReadSpaces(context);
                        this.OpenTag = this.ReadSingle<Tag>(context);
                    }
                    if (this.OpenTag != null)
                    {
                        int textStart = context.Position;
                        int textLength = 0;
                        while (true)
                        {
                            Tag tag = new Tag { Source = this.Source, Start = context.Position };
                            while (!tag.MarkBeginAndParse(context))
                            {
                                if (context.Position >= context.Source.Length)
                                {
                                    context.Position = startPos;
                                    return false;
                                }
                                context.Position++;
                                textLength++;
                            }
                            if (!tag.IsEndTag)
                            {
                                var tagGrpStart = context.Position;
                                var tagGrup = new TagsGroup(tag);
                                if (tagGrup.Parse(context))
                                {
                                    if (textLength > 0)
                                    {
                                        if (this.Contents == null) this.Contents = new List<Match>();
                                        this.Contents.Add(new Text { Source = this.Source, Start = textStart, Length = textLength });
                                        textStart = context.Position;
                                        textLength = 0;
                                    }
                                    this.Contents.Add(tagGrup);
                                }
                                else
                                {
                                    textLength += tag.Length;
                                }
                            }
                            else
                            {
                                if (tag.Name == this.OpenTag.Name)
                                {
                                    if (textLength > 0)
                                    {
                                        if (this.Contents == null) this.Contents = new List<Match>();
                                        this.Contents.Add(new Text { Source = this.Source, Start = textStart, Length = textLength });
                                        textStart = context.Position;
                                        textLength = 0;
                                    }
                                    this.CloseTag = tag;
                                    return true;
                                }
                                else
                                {
                                    textLength += tag.Length;
                                }
                            }
                        }
                    }
                    context.Position = startPos;
                    return false;
                }
                public Tag OpenTag { get; set; }
                public Tag CloseTag { get; set; }
                public List<Match> Contents { get; set; }
            }
            class Text : Match
            {
                protected override bool ParseInternal(ParseContext context)
                {
                    return true;
                }
            }
        }
    }
