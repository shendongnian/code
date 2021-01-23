     public enum ExceptionCodes
     {
      [ExceptionCode(1000)]
      InternalError,
     }
     public static (int code, string message) Translate(ExceptionCodes code)
            {
                return code.GetType()
                .GetField(Enum.GetName(typeof(ExceptionCodes), code))
                .GetCustomAttributes(false).Where((attr) =>
                {
                    return (attr is ExceptionCodeAttribute);
                }).Select(customAttr =>
                {
                    var attr = (customAttr as ExceptionCodeAttribute);
                    return (attr.Code, attr.FriendlyMessage);
                }).FirstOrDefault();
            }
