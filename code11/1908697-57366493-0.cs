    public class TestInputFormatter : IInputFormatter
    {
        public bool CanRead(InputFormatterContext context) => true;
        public async Task<InputFormatterResult> ReadAsync(InputFormatterContext context)
        {
            List<string> input = new List<string>();
            using (StreamReader reader = new StreamReader(context.HttpContext.Request.Body))
            {
                while (!reader.EndOfStream)
                {
                    string line = (await reader.ReadLineAsync()).Trim();
                    input.Add(line);
                }
            }
            return InputFormatterResult.Success(input.ToArray());
        }
    }
