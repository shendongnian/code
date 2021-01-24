    public class JsonStringInputFormatter : TextInputFormatter
    {
        public JsonStringInputFormatter() : base()
        {
            SupportedEncodings.Add(UTF8EncodingWithoutBOM);
            SupportedEncodings.Add(UTF16EncodingLittleEndian);
            SupportedMediaTypes.Add(MediaTypeNames.Application.Json);
        }
        public override bool CanRead(InputFormatterContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            return context.ModelType == typeof(string);
        }
        public override async Task<InputFormatterResult> ReadRequestBodyAsync(
            InputFormatterContext context, Encoding encoding)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            using (var streamReader = new StreamReader(
                context.HttpContext.Request.Body,
                encoding))
            {
                return await InputFormatterResult.SuccessAsync(
                    (await streamReader.ReadToEndAsync()).Trim('"'));
            }
        }
    }
