        ArrayList ImgArry = new ArrayList();
        path = objGetBaseCase.GetImages(TotImgIds);
        ImgArry.Add(SelImgId);
        ImgArry.Add(SelImgpath);//image name
        ImgArry.Add(SelImgName);//image path
        //path.Remove(ImgArry);
        List<ArrayList> t = new List<ArrayList>();
        if (newpath.Count > 0)
            t = newpath;
        t.Add(ImgArry);
        newpath = t;
        for (int i = 0; i < newpath.Count; i++)
        {
            ArrayList alst = newpath[i];
            newtb.Rows.Add(Convert.ToInt32(alst[0]), alst[1].ToString(), alst[2].ToString(), i);
        }
        dlstSelectedImages.DataSource = newtb;
        DataBind();
        path = objGetBaseCase.GetImages(TotImgIds);
        for (int i = 0; i < path.Count; i++)
        {
            ArrayList alst = path[i];
            tb.Rows.Add(Convert.ToInt32(alst[0]), alst[1].ToString(), alst[2].ToString(), i);
        }
        dlstImage.DataSource = tb;
        DataBind();
