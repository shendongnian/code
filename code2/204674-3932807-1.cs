    public static class TemplateExtensions
    {
        public static T Find<T>(this ICollection<T> templates, string templateID) where T : ITemplate
        {
            T selectedTemplate;
            if (templates.Count == 0)
                throw new CreatioException("This user's brand has no templates. There must be at least one available.");
            if (templates.Count == 1 || String.IsNullOrEmpty(templateID))
                selectedTemplate = templates.First();
            else
                selectedTemplate = templates.Single(x => x.TemplateId.ToLower() == templateID.ToLower());
            if (selectedTemplate == null)
                throw new CreatioException(String.Format("No template with the id {0} could be found for this user's brand.", templateID));
            return selectedTemplate;
        }
    }
