        public async Task Edit(Menu menu)
        {
            menu.UpdatedBy = _userId;
            menu.UpdatedDate = DateTime.Now;
            var editVersion = await Find(menu.MenuId);
            if (editVersion != null)
            {
                _db.Entry(editVersion).CurrentValues.SetValues(menu);
            }
            await _db.SaveChangesAsync();
        }
