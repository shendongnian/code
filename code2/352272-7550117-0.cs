        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            var count = form.Count;
            int i = 0;
            while(i <= count)
            {
                
                var ValueCollection = form.Get(i);
                var KeyName = form.GetKey(i);
                foreach(var value in ValueCollection)
                {
                    //Your logic
                }
                i++;
            }
            return View();
        }
