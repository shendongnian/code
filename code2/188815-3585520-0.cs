    public static Element Load(int id)
    {
        using (var db = DataContextFactory.Create<ElementContext>())
        {
            var translations = from t in db.Translations
                               where t.Fk_Element_Id == id
                               join l in db.Languages on t.FK_Language_Id equals l.Id
                               select new Translation(t, l);
            return new Element(db.Elements.Where(x => x.Id == id).Single(), translations);
        }
    }
