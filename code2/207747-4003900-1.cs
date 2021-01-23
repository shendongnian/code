    class basic { }
    class symbol : basic { }
    class numeric : basic { }
    class ex {
        public static implicit operator ex(basic b) {
            return new ex();
        }
        public static implicit operator basic(ex e) {
            return new basic();
        }
        public static ex operator + (basic lh, ex rh) {
            return new ex();
        }
    }
    class Program {
        static void Main(string[] args) {
            symbol s = new symbol();
            numeric n = new numeric();
            // ex e0 = s + n; //error!
            ex e1 = (ex)s + n; //works
            ex e2 = s + (ex)n; //works
            ex e3 = (ex)s + (ex)n; //works
        }
    }
