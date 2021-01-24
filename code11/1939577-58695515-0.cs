        public IActionResult EditMember(Guid? id)
        {
            var titleId = _context.Members.Where(x => x.RowId == id).Select(y => y.TitleId).FirstOrDefault();
            var editMember = new MemberViewModel
            {
                Titles =  _context.Titles.Select(g => new SelectListItem
                {
                    Value = g.ToString(),
                    Text = g.ToString(),
                    Selected = (g == titleId)
                }).ToList();
            };
            return View(editMember);
        }
