    public IList<UnitTemplate> UnitTemplates { get; set; }
    public IList<QualTemplate> QualTemplates { get; set; }
    public QualTemplate FindQualTemplate(string templateID)
    {
        return FindTemplatesImpl(templateID, x => x.QualTemplateID, QualTemplates );
    }
    public UnitTemplate FindUnitTemplates(string templateID)
    {
        return FindTemplatesImpl(templateID, x => x.UnitTemplateID, UnitTemplates );
    }
    public T FindTemplatesImpl<T>(string templateID, Func<T, string> expr, IList<T> templates)
    {
        T selectedTemplate;
        if (templates.Count == 0)
            throw new CreatioException("This user's brand has no Templates. There must be at least one available.");
        if (templates.Count == 1 || String.IsNullOrEmpty(templateID))
            selectedTemplate = templates.First();
        else
            selectedTemplate = templates.Single(x => expr(x).ToLower() == templateID.ToLower());
        if (selectedTemplate == null)
            throw new CreatioException(String.Format("No UnitTemplate with the id {0} could be found for this user's brand.", templateID));
        return selectedTemplate;
    }
