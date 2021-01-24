    public static T GetSource<T>(this ContextCacheKey contextCacheKey)
        {
            var source = (T)typeof(ContextCacheKey).GetField("_source", BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance)?.GetValue(contextCacheKey);
            return source;
        }
        public class ElementConverter : IValueConverter<Element, Models.Element>
        {
            public Models.Element Convert(Element sourceMember, ResolutionContext context)
            {
                var a = (Models.Element)context.InstanceCache.FirstOrDefault(kvp => kvp.Key.GetSource<Element>().Id.Equals(sourceMember.Id)).Value ?? context.Mapper.Map<Models.Element>(sourceMember);
                return a;
            }
        }
