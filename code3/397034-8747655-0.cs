    public class Quotes { 
        public string symbol; 
        public string extension;
        public override bool Equals(object obj) {
            if (!(obj is Quotes)) { return false; }
            return (this.symbol == ((Quotes)obj).symbol) && 
                   (this.extension == ((Quotes)obj).extension);
        }
        public override int GetHashCode() {
            return (this.symbol.GetHashCode()) ^ (this.extension.GetHashCode());
        }
    } 
