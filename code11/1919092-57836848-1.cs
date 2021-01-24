    t_Section eSection = new t_Section
        {
            SectionId = model.SectionId,
            Section = model.Section,
            SectionTypeId = model.SectionTypeId,
            SectionOrdinal = model.SectionOrdinal,
            ModifyDate = DateTime.Now,
            ModifyUserName = User.Identity.Name,
            LastChangeId = newChangeId
        };
        db.Entry(eSection).State = EntityState.Modified;
        db.SaveChanges();
