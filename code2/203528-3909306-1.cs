    public static class BrothersExntension
        {
            public static void SetAsBrother(this IFormBrothers form, IFormBrothers brother)
            {
                if (form.Brothers == null)
                    form.Brothers = new List<IFormBrothers>();
    
                if (form.Brothers.Contains(brother))
                    return;
    
                form.Brothers.Add(brother);
                brother.SetAsBrother(form);
    
                (form as Form).SizeChanged += (s, e) =>
                    {
                        foreach (var item in form.Brothers)
                            (item as Form).Width = (s as Form).Width;
                    };
            }
        }
