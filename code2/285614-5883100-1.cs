        public virtual ActionResult List(ModelMetadata modelMetadata, Guid? selected)
        {
            ViewData.Model = queryService.GetList(new GetCategoryListQueryContext())
                .Select(x => new SelectListItem
                                 {
                                     Text = x.Name,
                                     Value = x.Id.ToString(),
                                     Selected = selected.HasValue && x.Id == selected
                                 })
                .ToList();
    
            //it is important to set up ModelMetadata after model
            ViewData.ModelMetadata = modelMetadata;
    
            return View();
        }
