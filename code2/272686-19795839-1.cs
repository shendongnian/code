        public List<SelectListItem> EmployerList
        {
            get
            {
                return Employers.Select(x => new SelectListItem
                {
                    Text = x.EAN + "|" + x.Name,
                    Value = x.Id.ToString(),
                    Selected = (SelectedEmployer != null && SelectedEmployer.Id == x.Id)
                }).ToList();
            }
        }
