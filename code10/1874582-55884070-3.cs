                if (the_enumerable is IList)
                {
                    editableType = typeof(List<>).MakeGenericType(new[] { type });
                }
                else if(the_enumerable is ICollection)
                {
                    ......
                }
