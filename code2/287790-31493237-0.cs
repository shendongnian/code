    void WriteNode(System.IO.StreamWriter _file, HtmlNode _node, int _indentLevel)
        {
            // check parameter
            if (_file == null) return;
            if (_node == null) return;
            // init 
            string INDENT = " ";
            string NEW_LINE = System.Environment.NewLine;
            // case: no children
            if(_node.HasChildNodes == false)
            {
                for (int i = 0; i < _indentLevel; i++)
                    _file.Write(INDENT);
                _file.Write(_node.OuterHtml);
                _file.Write(NEW_LINE);
            }
            // case: node has childs
            else
            {
                // indent
                for (int i = 0; i < _indentLevel; i++)
                    _file.Write(INDENT);
                // open tag
                _file.Write(string.Format("<{0} ",_node.Name));
                if(_node.HasAttributes)
                    foreach(var attr in _node.Attributes)
                        _file.Write(string.Format("{0}=\"{1}\" ", attr.Name, attr.Value));
                _file.Write(string.Format(">{0}",NEW_LINE));
                // childs
                foreach(var chldNode in _node.ChildNodes)
                    WriteNode(_file, chldNode, _indentLevel + 1);
                // close tag
                for (int i = 0; i < _indentLevel; i++)
                    _file.Write(INDENT);
                _file.Write(string.Format("</{0}>{1}", _node.Name,NEW_LINE));
            }
        }
