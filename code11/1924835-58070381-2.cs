            public static class JsonExtensions
            {
                public static bool HasAny(this JToken token, Func<JToken, bool> predicate)
                {
                    return token != null && token.Children().Any(t => predicate(t));
                }
            }
