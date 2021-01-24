    var currentUser = Authentication.GetGlobalUserName();
                       
      db.Configuration.LazyLoadingEnabled = false;
                    //this is working from posts back to categories.
                    var approveposts = db.Announcement_posts
                        .Include(a => a.Categories)
                        .Include(a => a.Categories.Select(b => b.ParentCategory))
                        .Include(a => a.Categories.Select(c => c.Categories_approvers))
                        .Include(a => a.Announcement_approvals)
                        .Where(a => a.Announcement_approvals
                              .Any(b => b.approver == currentUser && a.approved == false)              
                        .Select(p => new PendingPostsVm
                        {
                            PostGuid = p.postGUID,
                            Topic = p.Categories.Select(cat => cat.name).FirstOrDefault(),
                            Theme = p.Categories.Select(cat => cat.ParentCategory.name).FirstOrDefault(),
                            PostTitle = p.title,
                            Catid = p.Categories.Select(cat => cat.id).FirstOrDefault(),
                            DateSubmitted = p.date_created
                        })
                        .OrderBy(s => s.DateSubmitted)
                        .ToList();
