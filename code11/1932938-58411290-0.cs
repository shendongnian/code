        class a
        {
            public int myMethod(int data, Func<int, int> func)
            {
                return func.Invoke(data);
            }
        }
        class b
        {
            public void anotherMethod()
            {
                var classA = new a();
                var result = classA.myMethod(8, Double);
            }
            private int Double(int i)
            {
                return i * 2;
            }
        }
