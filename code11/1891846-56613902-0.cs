    static void Main(string[] args)
    {
        var a = false;
        a.OrThrow();
    }
        
    }
    public static class ThrowExtension {
        public static void OrThrow(this bool b)
        {
            if(!b)
                throw new Exception();
        }
    }
