         public async Task <bool> UpdateProfilePic(updateprofilepicmodel model)
    {
        using (ClientContext context = SPConnection.GetSharePointContext())
        {
            List list = context.Web.Lists.GetByTitle("Members");
            ListItem item = list.GetItemById(model.MemberId);
            context.Load(item);
            Task t1 = context.ExecuteQueryAsync();
            await t1.ContinueWith((t) =>
                {
                    item["ProfilePicture"] = model.ProfilepicUrl;
                    item.Update();
                    Task t2 = context.ExecuteQueryAsync();
                });
            
            await t2.ContinueWith((t) =>
                {
                   // do some stuff here if needed
                });
         
            return true;
        }
    }
