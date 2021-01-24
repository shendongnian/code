     ASPxTextBase MakeControl(String Type, String Name, int Length)
    {
        ASPxTextBase tbBase = null;
        switch (Type)
        {
            case "COMBO":
                tbBase = new ComboBox()
                {
                    Items = new List<string>()
                };
                break;
            case "DATE":
                tbBase = new DateEdit()
                {
                    Date = DateTime.Now
                };
                break;
            default:
                throw new ArgumentException(nameof(Type));
        }
        tbBase.Name = Name;
        tbBase.Length = Length;
        return tbBase;
    }
I made some fake properties for what I imagined the Combo or Date types might have.
