    public static HelperResult RenderHelper(this ViewDataDictionary<dynamic> viewDataDictionary, string helperName)
    {
        Func<HelperResult> helper = viewDataDictionary[helperName] as Func<HelperResult>;
        if (helper != null)
        {
            return helper();
        }
    
        return null;
    }
