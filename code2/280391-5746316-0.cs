    public string GetDepartmentTitle(string DepartmentAbbreviation) {
        var items = TaxonomyFromCMS.GetAllItems(DomainDataConstants.DivisionAndDepartment.TAXONOMY_ID); 
        var result = items.SelectMany(item=>item.SubTaxonomyItems).FirstOrDefault(item=>item.Name == DepartmentAbbreviation);
        var text = result !=null  ? result.Title : String.Empty;
        return text;
    }
