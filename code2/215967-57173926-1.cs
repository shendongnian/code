        public static Array CreateJaggedArray<T>(params int[] lengths)
        {
            if(lengths.Length < 1)
                throw new ArgumentOutOfRangeException(nameof(lengths));
            void Populate(Array array,  int index)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    Array element = (Array)Activator.CreateInstance(array.GetType().GetElementType(), lengths[index]);
                    array.SetValue(element, i);
                    if (index + 1 < lengths.Length)
                        Populate(element, index + 1);
                }
            }
            Type retType = typeof(T);
            for (var i = 0; i < lengths.Length; i++)
                retType = retType.MakeArrayType();
            Array ret = (Array)Activator.CreateInstance(retType, lengths[0]);
            if (lengths.Length > 1)
                Populate(ret, 1);
            return ret;
        }
