        public static IBindingInNamedWithOrOnSyntax<T> WhenAnyAncestorIs<T>(this IBindingWhenSyntax<T> binding, params Type[] types)
        {
            bool Matches(IRequest request)
            {
                Type target = request.Target?.Member?.ReflectedType;
                return (target != null && types.Any(t => t == target))
                    || (request.ParentRequest != null && Matches(request.ParentRequest));
            }
            return binding.When(Matches);
        }
