        [HttpPost]
        [Route("Edit")]
        public JsonResult Edit([FromBody] CorpNotes newMessage)
        
            {return Json(TotalWeekNoteSearch);}
    public class CorpNotes
    {
        public int Departments { get; set; }
        public string Note { get; set; }
        public DateTime WeekEnding { get; set; }
    }
