    private ClassInstance GetMeANumber()
    {
        using (var a = new Resource())
        {
            return a.GetClassInstance();
        }
    }
