     public List<SelectListItem> GetListItems(List<IModelInterface> genModel)
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            foreach (var dyn in genModel)
            {
                lst.Add(new SelectListItem
                {
                    Text = dyn.Name,
                    Value = Convert.ToString(dyn.Id)
                });
            }
            return lst;
        }
