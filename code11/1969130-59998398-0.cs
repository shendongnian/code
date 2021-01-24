     private static int CheckDuplicatedDropdownQuestions(Template template, int i, 
    List<string> collectQuestions,string field)
    {
        if(field=="Dropdown")
        {
           NewMethod(template.Fields.Dropdown,ref i);
        }
        else if(field=="CheckBox")
        {
           NewMethod(template.Fields.CheckBox,ref i);
        }
        return i;
    }
    
    private static int NewMethod(var FieldType,ref int i)
    {
        foreach (var field in FieldType)
        {
            if (!collectQuestions.Contains(field.Title))
            {
                collectQuestions.Add(field.Title);
            }
            else
            {
                field.Title = field.Title + " (" + i + ")";
                i++;
            }
        }
    }
