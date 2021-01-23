     public string Get()
        {
            var list = _languageRepository.GetMany(l => l.LanguageTrans.FirstOrDefault().CultureCode == "en").ToList();
            string json = JsonConvert.SerializeObject(list, Formatting.Indented, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            return json;
        }
