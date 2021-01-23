    PostSubmitter post = new PostSubmitter();
            post.Url = "http://192.168.0.1/Invoice/Invoice1.aspx";
            post.PostItems.Add("subscriberid", subscriberid.ToString());
            post.PostItems.Add("StartDate", StartDate);
            post.PostItems.Add("EndDate", EndDate);
            post.PostItems.Add("AdvanceBillDate", AdvanceBillDate);
            post.Type = PostSubmitter.PostTypeEnum.Get;
            try
            {
                string res = post.Post();
            }
            catch (Exception exp)
            {
            }
 
