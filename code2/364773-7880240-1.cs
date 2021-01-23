        public static class MyCoolVertex
        {
            public static void AddVertexAndValidate(this List<int> list, Vertex value)
            {
                if(value.IsValid())
                    list.Add(value);
            }
        }
