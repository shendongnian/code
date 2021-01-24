    public List<Result> Convert(Contract.Dto.Result source, List<Result> destination, ResolutionContext context)
    {
        var listOfResults = new List<Result>();
        var result = context.Mapper.Map<Contract.Dto.Result, Result>(source);
        listOfResults.Add(result);
        return listOfResults;
    }
