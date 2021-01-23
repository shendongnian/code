    public class Quotes{ 
        public string symbol; 
        public string extension
        public override bool Equals(object obj)
        {
            Quotes q = obj as Quotes;
            return q != null && q.symbol == this.symbol && q.extension == this.Extension;
        }
    
        public override int GetHashCode()
        {
            return this.symbol.GetHashCode() ^ this.extension.GetHashCode();
        }
    }
