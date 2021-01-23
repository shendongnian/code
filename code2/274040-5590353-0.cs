    private string getRelatedNews(Taxonomy taxData, string related, string contentTitle)
    {
        foreach (TaxonomyItemData item in taxData.TaxonomyItems)
            {
                if (taxData.TaxonomyName.Equals(contentTitle) && taxData.TaxonomyItemCount != 0)
                {
                    related = string.Format("{0}<li><a href='{1}'\">{2}</a></li>", related, item.Link, item.Name);
                }                   
            }
        // Show all its sub categories
        foreach (TaxonomyData cat in taxData.Taxonomy)
            {   
                related = getRelatedNews(cat, related, contentTitle);
            }
    
        return(related);
    
    }
