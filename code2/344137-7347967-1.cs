    public BOEod CheckCommandStatus<T>(T pBo, IList<string> pProperties) where T : IBOEod
    {
        pBo.isValid = false;
        if (pProperties != null)
        {
            int Num=-1;
            pBo.GetType().GetProperty(pProperties[0].ToString()).GetValue(pBo, null);
            if (ifIntegerGetValue(pBo.GetType().GetProperty(pProperties[0].ToString()).GetValue(pBo, null).ToString(), out Num))
            {
                if (Num == 1)
                    pBo.isValid = true;
            }
    
        }
        return pBo;
    }
    public interface IBOEod
    {
        bool IsValid {get;set;}
    }
