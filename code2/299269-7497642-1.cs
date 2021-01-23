     public static IMappingExpression<A, T> ApplyBaseQuoteMapping<A, T>(this   IMappingExpression<A, T> iMappingExpression)
            where A : QuoteMessage
            where T : CalculationGipMessage
        {
            iMappingExpression
                .ForMember(a => a.LoginUserName, b=> b.MapFrom(c => c.LoginUserName))
                .ForMember(a => a.AssetTestExempt, b => b.Ignore())
                ;
            return iMappingExpression;
        }
    Mapper.CreateMap<QuoteMessage, CalculationGipMessageChild>()
                .ApplyBaseQuoteMappingToOldCol()
                 // do other mappings here
