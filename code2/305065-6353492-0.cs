    function GetItems(string keyword, string consultant, int? locationId, int categoryId){
    
    using(MyContextEntities context = new MyContextEntities()){
        return context.Items.Where(item => 
            (string.IsNullOrEmpty(keyword) || item.Text.Contains(keyword))
            && (string.IsNullOrEmpty(consultant) || item.Consultant.Contains(consultant))
            && (!locationId.HasValue || item.Location.Id == locationId.Value)
            && (!categoryId.HasValue || item.Category.Id == categoryId.Value)
        );
    }
    }
