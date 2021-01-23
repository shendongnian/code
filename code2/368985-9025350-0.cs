    public static Mock<T> GetOrMockAndStore<T>() where T : class
        {
            Mock<T> output;
            if (ScenarioContext.Current.TryGetValue(out output))
            {
                return output;
            }
            else
            {
                output = new Mock<T>();
                ScenarioContext.Current.Set(output);
            }
            return card;
        }
