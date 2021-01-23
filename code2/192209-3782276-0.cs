    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using Sgml;
    using System.Net;
    using System.Xml;
    using System.IO;
    using System.Diagnostics;
    namespace SharpQuery
    {
        using ReadyFunc = System.Action<SharpQuery>;
        public class SharpQuery : List<XmlNode>
        {
            XmlDocument _document;
            XmlNode _context;
            readonly static Regex _quickExpr = new Regex(@"^[^<]*(<[\w\W]+>)[^>]*$|^#([\w-]+)$");
            readonly static Regex _isSimple = new Regex(@"^.[^:#\[\.,]*$");
            readonly static Regex _notWhite = new Regex(@"\S");
            readonly static Regex _trim = new Regex(@"^(\s|\u00A0)+|(\s|\u00A0)+$");
            readonly static Regex _singleTag = new Regex(@"^<(\w+)\s*\/?>(?:<\/\1>)?$");
            readonly static Regex _chunker = new Regex(@"((?:\((?:\([^()]+\)|[^()]+)+\)|\[(?:\[[^[\]]*\]|['""][^'""]*['""]|[^[\]'""]+)+\]|\\.|[^ >+~,(\[\\]+)+|[>+~])(\s*,\s*)?((?:.|\r|\n)*)");
            readonly static Version _jQuery = new Version("1.4.2");
            static class _selectors
            {
                public static string[] order = new[] { "ID", "NAME", "TAG" };
                public static Dictionary<string, Regex> match = new Dictionary<string, Regex> {
                    { "ID", new Regex(@"#((?:[\w\u00c0-\uFFFF-]|\\.)+)") },
                    { "CLASS", new Regex(@"\.((?:[\w\u00c0-\uFFFF-]|\\.)+)") },
                    { "NAME", new Regex(@"\[name=['""]*((?:[\w\u00c0-\uFFFF-]|\\.)+)['""]*\]") },
                    { "ATTR", new Regex(@"\[\s*((?:[\w\u00c0-\uFFFF-]|\\.)+)\s*(?:(\S?=)\s*(['""]*)(.*?)\3|)\s*\]") },
                    { "TAG", new Regex(@"^((?:[\w\u00c0-\uFFFF\*-]|\\.)+)") },
                    { "CHILD", new Regex(@":(only|nth|last|first)-child(?:\((even|odd|[\dn+-]*)\))?") },
                    { "POS", new Regex(@":(nth|eq|gt|lt|first|last|even|odd)(?:\((\d*)\))?(?=[^-]|$)") },
                    { "PSEUDO", new Regex(@":((?:[\w\u00c0-\uFFFF-]|\\.)+)(?:\((['""]?)((?:\([^\)]+\)|[^\(\)]*)+)\2\))?") }
                };
                public static Dictionary<string, Action<HashSet<XmlNode>, string>> relative = new Dictionary<string, Action<HashSet<XmlNode>, string>> {
                    { "+", (checkSet, part) => {
                    }}
                };
                public static Dictionary<string, Func<string, XmlNode, bool, List<XmlNode>>> find = new Dictionary<string, Func<string, XmlNode, bool, List<XmlNode>>> {
                    { "ID", (id, context, isXml) => {
                        if(!isXml)
                        {
                            var elem = context.SelectSingleNode(string.Format("descendant::*[@id='{0}']", id));
                            if(elem != null) return new List<XmlNode> { elem };
                        }
                        return new List<XmlNode>();
                    }},
                    { "NAME", (name, context, isXml) => {
                        var results = context.SelectNodes(string.Format("descendant::*[@name='{0}']", name));
                        return results == null ? new List<XmlNode>() : results.Cast<XmlNode>().ToList();
                    }},
                    { "TAG", (tag, context, isXml) => {
                        var results = context.SelectNodes(string.Format("descendant::{0}", tag));
                        return results == null ? new List<XmlNode>() : results.Cast<XmlNode>().ToList();
                    }}
                };
                public static Dictionary<string, Regex> leftMatch = new Dictionary<string, Regex>();
                public static Regex origPOS = match["POS"];
                static _selectors()
                {
                    foreach (var type in match.Keys.ToArray())
                    {
                        _selectors.match[type] = new Regex(match[type].ToString() + @"(?![^\[]*\])(?![^\(]*\))");
                        _selectors.leftMatch[type] = new Regex(@"(^(?:.|\r|\n)*?)" + Regex.Replace(match[type].ToString(), @"\\(\d+)", (m) =>
                            @"\" + (m.Index + 1)));
                    }
                }
            }
            class SizzleResult
            {
                public List<XmlNode> set;
                public string expr;
            }
            string _userAgent = "???";
            bool _browserMatch;
            bool _readyBound = false;
            string _selector = "";
            bool _isReady = false;
            event EventHandler<EventArgs> _domContentLoaded;
            public event ReadyFunc Ready;
            public bool IsReady { get { return _isReady; } }
            #region Constructors
            public SharpQuery() { }
            public SharpQuery(string url) { Load(url); }
            public SharpQuery(Uri uri) { Load(uri); }
            public SharpQuery(XmlDocument doc)
            {
                _document = doc;
                _context = _document.DocumentElement;
                _isReady = true;
            }
            #endregion
            public SharpQuery Load(string url) { return Load(new Uri(url)); }
            public SharpQuery Load(Uri uri)
            {
                var req = (HttpWebRequest)WebRequest.Create(uri);
                req.BeginGetResponse((result) =>
                {
                    var resp = (HttpWebResponse)req.EndGetResponse(result);
                    var sgml = new SgmlReader();
                    sgml.DocType = "html";
                    sgml.WhitespaceHandling = WhitespaceHandling.All;
                    sgml.CaseFolding = CaseFolding.ToLower;
                    sgml.InputStream = new StreamReader(resp.GetResponseStream());
                    _document = new XmlDocument();
                    _document.PreserveWhitespace = true;
                    _document.XmlResolver = null;
                    _document.Load(sgml);
                    AddNodes(_document.ChildNodes);
                    _context = _document.DocumentElement;
                    _isReady = true;
                    if (Ready != null) Ready(this);
                }, null);
                return this;
            }
            public SharpQuery Truncate(int startingIndex)
            {
                RemoveRange(startingIndex, Count - startingIndex);
                return this;
            }
            public SharpQuery Init(XmlNode htmlElement)
            {
                if (htmlElement != null)
                {
                    _context = this[0] = htmlElement;
                    Truncate(1);
                }
                return this;
            }
            public SharpQuery Init(string selector, XmlElement context = null)
            {
                if (string.IsNullOrWhiteSpace(selector))
                    return this;
                var match = _quickExpr.Match(selector);
                if (match.Success && (match.Groups[1].Success || context == null))
                {
                    // HANDLE: Init(html) -> Init(array)
                    if (match.Groups[1].Success)
                    {
                        var doc = _context != null ? _context.OwnerDocument : _document;
                        var ret = _singleTag.Match(selector);
                        if (ret.Success)
                        {
                            throw new NotImplementedException("Cannot create element.");
                        }
                        else
                        {
                            throw new NotImplementedException("Cannot build DOM.");
                        }
                    }
                    else // HANDLE: Init("#id")
                    {
                        var elem = _document.SelectSingleNode(string.Format("//*[@id='{0}']", match.Groups[2].Value));
                        if (elem != null)
                        {
                            Truncate(1);
                            this[0] = elem;
                        }
                        _context = _document.DocumentElement;
                        _selector = selector;
                        return this;
                    }
                } // HANDLE: Init("TAG")
                else if (context == null && Regex.IsMatch(selector, @"\w+$"))
                {
                    _selector = selector;
                    _context = _document.DocumentElement;
                    var nodes = _document.GetElementsByTagName(selector);
                    return SetNodes(nodes);
                } // HANDLE: Init(expr, ...)
                else if (context == null || context is SharpQuery)
                {
                    throw new NotImplementedException("Cannot handle (expr, sq).");
                }
                else // HANDLE: Init(expr, context)
                {
                    throw new NotImplementedException("Cannot handle (expr, context)");
                }
            }
            private SharpQuery SetNodes(XmlNodeList nodes)
            {
                Clear();
                return AddNodes(nodes);
            }
            private SharpQuery SetRange(IEnumerable<XmlNode> nodes)
            {
                Clear();
                AddRange(nodes);
                return this;
            }
            private SharpQuery AddNodes(XmlNodeList nodes)
            {
                AddRange(nodes.Cast<XmlNode>());
                return this;
            }
            public SharpQuery Init(ReadyFunc action)
            {
                Ready += action;
                return this;
            }
            private static void BindReady()
            {
                throw new NotImplementedException();
            }
            private static bool IsPlainObject(object obj)
            {
                return obj.GetType() == typeof(object);
            }
            private static SharpQuery Merge(SharpQuery first, IEnumerable<XmlNode> second)
            {
                first.AddRange(second);
                return first;
            }
            public List<XmlNode> Get()
            {
                return this;
            }
            public XmlNode Get(int i)
            {
                return i < 0 ? this[Count - i] : this[i];
            }
            public SharpQuery Eq(int i)
            {
                this[0] = Get(i);
                return Truncate(1);
            }
            public SharpQuery First
            {
                get { return Eq(0); }
            }
            public SharpQuery Last
            {
                get { return Eq(-1); }
            }
            public static IEnumerable<T> Grep<T>(IEnumerable<T> elems, Func<T, int, bool> callback, bool inv)
            {
                int i = 0;
                foreach(var e in elems)
                    if (inv == callback(e, i++))
                        yield return e;
            }
            public SharpQuery Find(string selector)
            {
                var ret = new List<XmlNode>();
                foreach(var n in this)
                {
                    ret.AddRange(Sizzle(selector, n));
                    // TODO: check for uniqueness
                }
                return SetRange(ret);
            }
            public static IEnumerable<XmlNode> Sizzle(string selector, XmlNode context, IEnumerable<XmlNode> seed = null)
            {
                if (context.NodeType != XmlNodeType.Element && context.NodeType != XmlNodeType.Document)
                    yield break;
                if (string.IsNullOrWhiteSpace(selector))
                    yield break;
                string soFar = selector;
                Match m;
                Queue<string> parts = new Queue<string>();
                string extra;
                List<XmlNode> set = null;
                bool contextXml = IsXml(context);
                while ((m = _chunker.Match(soFar)).Success)
                {
                    soFar = m.Groups[3].Value;
                    parts.Enqueue(m.Groups[1].Value);
                    if (m.Groups[2].Success)
                    {
                        extra = m.Groups[3].Value;
                        break;
                    }
                }
                if (parts.Count > 1 && _selectors.origPOS.IsMatch(selector))
                {
                    if (parts.Count == 2 && _selectors.relative.ContainsKey(parts.Peek()))
                    {
                        throw new NotImplementedException();
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }
                }
                else
                {
                    if (seed == null && parts.Count > 1 && context.NodeType == XmlNodeType.Document && !contextXml &&
                        _selectors.match["ID"].IsMatch(parts.First()) && !_selectors.match["ID"].IsMatch(parts.Last()))
                    {
                        throw new NotImplementedException("Sizzle.find");
                    }
                    if (context != null)
                    {
                        var ret = seed != null ? new SizzleResult{expr=parts.Dequeue(), set=null} :
                            SizzleFind(parts.Dequeue(), parts.Count == 1 && 
                                (parts.First() == "~" || parts.First() == "+") && 
                                context.ParentNode != null ? context.ParentNode : context, contextXml);
                        set = !string.IsNullOrWhiteSpace(ret.expr) ? /* filter */ret.set : ret.set;
                        // TODO: some junk here
                    
                    }
                }
                foreach (var n in set)
                    yield return n;
            }
            private static SizzleResult SizzleFind(string expr, XmlNode context, bool isXml)
            {
                List<XmlNode> set = null;
                if (string.IsNullOrWhiteSpace(expr))
                    return null;
                foreach (string type in _selectors.order)
                {
                    Match match;
                    if ((match = _selectors.leftMatch[type].Match(expr)).Success)
                    {
                        var left = match.Groups[2].Value; // FIXME: JavaScript version has index as 1
                        //match = match.NextMatch();
                    
                        if (!left.EndsWith(@"\"))
                        {
                            var part = left.Replace(@"\", "");
                        
                            set = _selectors.find[type](part, context, isXml);
                            if (set.Count > 0)
                            {
                                expr = _selectors.match[type].Replace(expr, "");
                                break;
                            }
                        }
                    }
                }
                if (set == null)
                {
                    // TODO: not sure if this right
                    set = context.ChildNodes.OfType<XmlElement>().Cast<XmlNode>().ToList();
                }
                return new SizzleResult { set = set, expr = expr };
            }
            private static bool IsXml(XmlNode elem)
            {
                if (elem == null) return false;
                var documentElement = elem.OwnerDocument.DocumentElement;
                return documentElement != null ? documentElement.Name != "html" : false;
            }
        }
    }
