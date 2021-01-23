    public static IEnumerable<MyResult> AwesomeHelper(this IEnumerable<SomeBigExternalDTO> input, 
                                                      Func<SomeBigExternalDTO, int> intMapper)
    {
        foreach (var item in input)
            yield return new MyResult() 
            {
                UserId = item.UserId, 
                ResultValue = intMapper(item) 
            };
    }
