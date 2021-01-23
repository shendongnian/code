    public string Byline
            {
                get { return !_elements.ContainsKey("Byline") ? "" : (string)_elements["Byline"]; }
                set
                {
                    string _buf = Functions.StripTags(value);
                    _elements["Byline"] = _buf;
                }
            }
