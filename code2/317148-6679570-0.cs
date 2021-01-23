    private static ParameterSettings[] GetListOfParametersFromIndicator(object indicatorClass, int loopId, myEnums.ParaOrResult paraOrResult)
        {
            return (from prop in indicatorClass.GetType().GetProperties()
                     let loopID = loopId
                    let Indicator = indicatorClass.GetType().Name
                    let value = (object)prop.GetValue(indicatorClass, null)
                     where prop.Name.Contains("_Constr_")
                    select new ParameterSettings { ParaOrResult=paraOrResult, LoopID= loopId, Indicator= Indicator, ParaName= prop.Name, Value= value }).ToArray();
        }
