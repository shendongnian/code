            var file = Path.Combine(Server.MapPath("~/Content/xml"), "countries.xml"); 
            XmlDocument doc = new XmlDocument();
            
            doc.Load(file);
            XmlNodeList countryList = doc.GetElementsByTagName("Country");
            List<SelectListItem> countries = new List<SelectListItem>(); 
            foreach (XmlNode country in countryList) 
            { 
                string name = country.ChildNodes[0].InnerText; 
                string code = country.ChildNodes[1].InnerText; 
                countries.Add(new SelectListItem 
                { 
                    Text = name, 
                    Value = code 
                }); 
            }
            ViewBag.country = new SelectList(countries, "Value", "Text");
            return View();
