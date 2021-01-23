    public BOEod CheckCommandStatus<T>(T pBo, IList<string> pProperties) where T : IBOEod
    {
        pBo.isValid = false;
        if (pProperties != null)
        {
            int Num = -1;
            string propValue = pBo.GetType().GetProperty(pProperties[0].ToString()).GetValue(pBo, null).ToString();
            if (ifIntegerGetValue(propValue, out Num))
            {
                if (Num == 1)
                    pBo.isValid = true;
            }
        }
        return pBo;
    }
    public interface IBOEod
    {
        bool IsValid { get; set; }
    }
