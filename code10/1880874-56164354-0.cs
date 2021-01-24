cs
public ConversionRateProfile()
{
    CreateMap<ConversionRate, RateDto>();
    CreateMap<RateDto, ConversionRate>(MemberList.Source);
}
