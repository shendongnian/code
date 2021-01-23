        public static Array CreateJaggedArray<T>(params int[] lengths)
        {
            void Populate(Array array, int[] lengths2, int length = 1)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    Array element = (Array)Activator.CreateInstance(array.GetType().GetElementType(), lengths2[length]);
                    array.SetValue(element, i);
                    if (length + 1 < lengths2.Length)
                        Populate(element, lengths2, length + 1);
                }
            }
            Type retType = typeof(T);
            for (var i = 0; i < lengths.Length; i++)
                retType = retType.MakeArrayType();
            Array ret = (Array)Activator.CreateInstance(retType, lengths[0]);
            Populate(ret, lengths);
            return ret;
        }
