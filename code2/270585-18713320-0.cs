    public static class EquivelantStructureConversion<TInput, TOutput>
        where TInput : class
        where TOutput : new()
    {
        public static TOutput Convert(TInput input)
        {
            var output = new TOutput();
            foreach (var inputProperty in input.GetType().GetProperties())
            {
                var outputProperty = output.GetType().GetProperty(inputProperty.Name);
                if (outputProperty != null)
                {
                    var inputValue = inputProperty.GetValue(input, null);
                    outputProperty.SetValue(output, inputValue, null);
                }
            }
            return output;
        }
    }
