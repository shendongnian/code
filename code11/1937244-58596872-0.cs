    public virtual  string  ReadString() {
        if (this.ReadState != ReadState.Interactive) {
            return string.Empty;
        }
        this.MoveToElement();
        if (this.NodeType == XmlNodeType.Element) {
            if (this.IsEmptyElement) {
                return string.Empty;
            }
            else if (!this.Read()) {
                throw new InvalidOperationException(Res.GetString(Res.Xml_InvalidOperation));
            }
            if (this.NodeType == XmlNodeType.EndElement) {
                return string.Empty;
            }
        }
        string result = string.Empty;
        while (IsTextualNode(this.NodeType)) {
            result += this.Value;
            if (!this.Read()) {
                break;
            }
        }
        return result;
    }
