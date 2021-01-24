    ActionResult Post(){
        var latest = context.Post.OrderByDesc(x=>x.CreatedWhen).FirstOrDefault();
        var disable = (DateTime.Now - latest.CreatedWhen).Seconds < 60;
        if(disable){
            ViewBag.Disable = true;
        }
    }
