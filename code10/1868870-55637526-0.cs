        public ActionResult getFromDataBase()
        {
           // create object for your context of Database
            var studentContext = new studentContext();
           // return tablename data you want to retrieve in view
            return View(studentContext.TableName.ToList());
        
        }
