    public class MyTypeConverter : TypeConverter<BaseViewModel, BaseDto>
    {
        protected override BaseDto ConvertCore(BaseViewModel tViewModel)
        {
            BaseDto vResult = null;
            if(tViewModel is FirstViewModelImpl)
            {
                var vSource = tViewModel as FirstViewModelImpl;
                vResult = Mapper.Map<FirstViewModelImpl,FirstDtoImpl>(vSource);
            }
            else if(tViewModel is SecondViewModelImpl )
            {
                var vSource = tViewModel as SecondViewModelImpl ;
                vResult = Mapper.Map<SecondViewModelImpl ,SecondDtoImpl>(vSource);
            }
            return vResult;
        }
    }
