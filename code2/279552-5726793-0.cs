            Type type = ret.GetType();
            Type listType = typeof(IEnumerable<T>);
            if (type == listType || type.IsSubclassOf(listType))
            {
                //
            }
