    public static ResponseExtensions
    {
        public static Response ToResponse(this object source)
        {
            return new Response { Contents = source.ToString(); };
        }
    }
