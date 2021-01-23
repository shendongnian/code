        public class TypeDescriptor
        {
            private MyDataType _dataType;
            public TypeDescriptor(MyDataType dataType)
            {
                _dataType = dataType;
            }
            public override string ToString()
            {
                return _dataType.ToString();
            }
        }
