        [HttpPost]
        public ActionResult Create(KeyDate keyDate, int topic)
        {
            keyDate.Created = DateTime.Now;
            keyDate.CreatedBy = User.Identity.Name;
            // Create topic association
            Association keyDateTopic = new Association();
            keyDateTopic.CategoryID = topic;
            // create this list
            keyDate.Associations = new List<Association>();
            keyDate.Associations.Add(keyDateTopic); // <-- Object reference... error here
            repository.Add(keyDate);
            repository.Save();
            return RedirectToAction("Index");
        }
