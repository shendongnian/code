    [HttpPost]
    public ActionResult Index(string[] QuestionAnswer)
    {
        // each QuestionAnswer contains only checked value in questionid_answer format
        // like :
        // 1_ansone
        // 1_ansone
        // 2_anstwo
        // 3_ansthree
        foreach(var item in QuestionAnswer){
            int id = Convert.ToInt32(item.Split('_')[0].Trim());
            string answer = item.Split('_')[1].Trim();
            // do save to database or map to model logic here
        }
        return RedirectToAction("Debug");
    }
