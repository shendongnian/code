    public void DeleteComment(CommentModel commentToDelete) 
    {
        // Delete from list
        commentToDelete.Post.Comments.Remove(commentToDelete);
        
        // This is needed because the Comments is an Inverse collection
        commentToDelete.Post = null;
    
        // Update parent
        Update(commentToDelete.Post);
        // Delete the comment
        Delete(commentToDelete);
    }
