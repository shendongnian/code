            public void get_json(String TYPE)
            {
                CancelView();
                CancelLayout();
                Type t = Type.GetType("campusMap.Models."+TYPE);
                Ijson_autocomplete theclass = (Ijson_autocomplete)Activator.CreateInstance(t);
                RenderText(theclass.get_json_data());
            }
