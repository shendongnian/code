        public static void ValidateCache(HttpContext context, Object data, ref HttpValidationStatus status)
        {
            bool isEditor = /*assignment here*/;
            if (!isEditor)
            {
                status = HttpValidationStatus.Valid;
            }
            else
            {
                status = HttpValidationStatus.IgnoreThisRequest;
            }
        }
