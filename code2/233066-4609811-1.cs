            var post = new Post(){ Id = 2 };
            post.Title = "New Title After Update";
            // Must create a new instance to hold final attached entity
            var attachedPost = session.Merge(post);
            session.Update(attachedPost);
            session.Flush();
            // Use attachedPost after this if still needed as in session entity
