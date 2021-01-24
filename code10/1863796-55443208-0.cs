    protected void btnLike_Click(object sender, EventArgs e)
            {
    //you need to get postId while button clicked... 
                DBContext db = new DbContext();
                var user = Session["loggedUser"] as User ;
                var didUserLike = db.Post.Where(p=>p.PostId == postId).Select(x=>x.UserId == user.UserId).FirstOrDefault());
    if(didUserLike.Count() > 0){
    //Operation like enable button disable button!
    }   //and if you want to do it for dislike..yes you can
            }
