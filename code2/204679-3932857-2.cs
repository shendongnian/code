    public static class Extension {
    
         public static T FindTemplates<T>(this IList<T> list, string templateID, Func<string,T> selector) 
           {
            T selectedTemplate;
            if (list.Count == 0){
                throw new CreationException("This user's brand has no UnitTemplates. There must be at least one available.");
            }
            if (list.Count == 1 || String.IsNullOrEmpty(templateID)){
                selectedTemplate =  list.First();
            }
            else{
                selectedTemplate = selector(templateID); 
            }
            if (selectedTemplate == null){
                throw new CreationException(String.Format("No UnitTemplate with the id {0} could be found for this user's brand.", templateID));
            }
            return selectedTemplate;
        }
      }
