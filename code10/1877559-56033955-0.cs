    private string Sanitize(string text)
            {
                return Sanitizer.Sanitize(text, "", NoEntityMarkupFormatter.Instance);
            }
    
            private class NullEntityResolver : IEntityProvider
            {
                public string GetSymbol(string name)
                {
                    return null;
                }
            }
    
            private class NoEntityMarkupFormatter : IMarkupFormatter
            {
                internal static readonly NoEntityMarkupFormatter Instance = new NoEntityMarkupFormatter();
                private static readonly IMarkupFormatter defaultFormatter = HtmlMarkupFormatter.Instance;
    
                public string Text(string text)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < text.Length; i++)
                        switch (text[i])
                        {
                            // Change: Don't do this as we aren't decoding incoming entities
                            // case '&': sb.Append("&amp;"); break;
                            case '\xA0': sb.Append("&nbsp;"); break;
                            case '>': sb.Append("&gt;"); break;
                            case '<': sb.Append("&lt;"); break;
                            default: sb.Append(text[i]); break;
                        }
                    return sb.ToString();
                }
    
                public string Comment(IComment comment)
                {
                    return defaultFormatter.Comment(comment);
                }
    
                public string Processing(IProcessingInstruction processing)
                {
                    return defaultFormatter.Processing(processing);
                }
    
                public string Doctype(IDocumentType doctype)
                {
                    return defaultFormatter.Doctype(doctype);
                }
    
                public string OpenTag(IElement element, bool selfClosing)
                {
                    var sb = new StringBuilder();
                    sb.Append('<');
    
                    if (!string.IsNullOrEmpty(element.Prefix))
                        sb.Append(element.Prefix).Append(':');
    
                    sb.Append(element.LocalName);
    
                    foreach (var attribute in element.Attributes)
                        sb.Append(" ").Append(Instance.Attribute(attribute));
    
                    sb.Append('>');
                    return sb.ToString();
                }
    
                public string CloseTag(IElement element, bool selfClosing)
                {
                    return defaultFormatter.CloseTag(element, selfClosing);
                }
    
                public string Attribute(IAttr attr)
                {
                    var namespaceUri = attr.NamespaceUri;
                    var localName = attr.LocalName;
                    var value = attr.Value;
                    var sb = new StringBuilder();
    
                    if (string.IsNullOrEmpty(namespaceUri))
                        sb.Append(localName);
                    else if (Is(namespaceUri, NamespaceNames.XmlUri))
                        sb.Append(NamespaceNames.XmlPrefix).Append(':').Append(localName);
                    else if (Is(namespaceUri, NamespaceNames.XLinkUri))
                        sb.Append(NamespaceNames.XLinkPrefix).Append(':').Append(localName);
                    else if (Is(namespaceUri, NamespaceNames.XmlNsUri))
                        sb.Append(XmlNamespaceLocalName(localName));
                    else
                        sb.Append(attr.Name);
    
                    sb.Append('=').Append('"');
    
                    for (var i = 0; i < value.Length; i++)
                        switch (value[i])
                        {
                            // Change: Don't do this as we aren't decoding incoming entities
                            // case '&': temp.Append("&amp;"); break;
                            case '\xA0': sb.Append("&nbsp;"); break;
                            case '"': sb.Append("&quot;"); break;
                            default: sb.Append(value[i]); break;
                        }
    
                    return sb.Append('"').ToString();
                }
    
                private static bool Is(string a, string b)
                {
                    return string.Equals(a, b, StringComparison.Ordinal);
                }
    
                private static string XmlNamespaceLocalName(string name)
                {
                    return Is(name, NamespaceNames.XmlNsPrefix) ? name : string.Concat(NamespaceNames.XmlNsPrefix, ":");
                }
            }
    
            private static readonly Configuration TextWithoutEntityConfiguration =
                new Configuration().WithCss(e => e.Options = new CssParserOptions
                {
                    IsIncludingUnknownDeclarations = true,
                    IsIncludingUnknownRules = true,
                    IsToleratingInvalidConstraints = true,
                    IsToleratingInvalidValues = true
                }).With(new NullEntityResolver());
    
            private static readonly HtmlSanitizer Sanitizer = new HtmlSanitizer
            {
                HtmlParserFactory = () => new HtmlParser(TextWithoutEntityConfiguration)
            };
