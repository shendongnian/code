        @Override
        protected void provideElements()
        {
            for (int i = 0; i < size && !iterationAborted(); ++i)
            {
                provideElement(data[i]);
            }
        }
