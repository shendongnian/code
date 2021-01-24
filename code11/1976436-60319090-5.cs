        using System.Web.Script.Serialization;
        [HttpPost]
        public ActionResult Post(string json) 
        {
            var serializer = new JavaScriptSerializer();
            dynamic jsondata = serializer.Deserialize(json, typeof(object));
            //Get your variables here from AJAX call
            var myquestion= jsondata["myquestion"];
            try
            {
                var newEntry = new Question() { Id = 1, Question= myquestion};
                context.Question.Add(newEntry);
                context.SaveChanges();
                return Ok();
            } catch (Exception e)
            {
                return BadRequest();
            }
        }
