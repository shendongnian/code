        public void test(Int j)
        {
            if(TestOnJThatcanThrowOutOfMemoryException(j))
            {
                throw new OutOfMemoryException();
            }
        }
