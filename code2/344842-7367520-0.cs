            var q = from e in MainCategories
                    let t = Translations.Where(t => t.Name == "MainCategory" 
                        && t.RowKey == e.Id 
                        && t.Language.Code == "en-US").SingleOrDefault()
                    select new TranslatedEntity<Category>
                               {
                                   Entity = e,
                                   Translation = new TranslationDef
                                                     {
                                                         Language = t.Language.Code,
                                                         Name = t.Name,
                                                         Xml = t.Xml
                                                     }
                               };
