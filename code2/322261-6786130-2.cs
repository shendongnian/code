        Dictionary<string, string> values = new Dictionary<string, string>();
        values.Add("name", "value");
        TemplateValues tv = new TemplateValues(values);
        Assert.AreEqual("valUE", tv.ApplyValues("$(name:ue=UE)"));
        /// <summary>
        /// Matches a makefile macro name in text, i.e. "$(field:name=value)" where field is any alpha-numeric + ('_', '-', or '.') text identifier
        /// returned from group "field".  the "replace" group contains all after the identifier and before the last ')'.  "name" and "value" groups
        /// match the name/value replacement pairs.
        /// </summary>
        class TemplateValues
        {
                static readonly Regex MakefileMacro = new Regex(@"\$\((?<field>[\w-_\.]*)(?<replace>(?:\:(?<name>[^:=\)]+)=(?<value>[^:\)]*))+)?\)");
                IDictionary<string,string> _variables;
                public TemplateValues(IDictionary<string,string> values)
                { _variables = values; }
                public string ApplyValues(string template)
                {
                    return Transform(input, MakefileMacro, ReplaceVariable);
                }
                private string ReplaceVariable(Match m)
                {
                        string value;
                        string fld = m.Groups["field"].Value;
                        if (!_variables.TryGetValue(fld, out value))
                        {
                                value = String.Empty;
                        }
                        if (value != null && m.Groups["replace"].Success)
                        {
                                for (int i = 0; i < m.Groups["replace"].Captures.Count; i++)
                                {
                                        string replace = m.Groups["name"].Captures[i].Value;
                                        string with = m.Groups["value"].Captures[i].Value;
                                        value = value.Replace(replace, with);
                                }
                        }
                        return value;
                }
        }
