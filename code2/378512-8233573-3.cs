    try
    {
       ItemManager.SaveTextPost(myPostItem);
       // SaveTextPost can throw some exceptions (that you know)
    }
    catch (Exception e)
    {
       // You know the exceptions that SaveTextPost can return, so threat them 
       // correctly
       if (e == FileNotFoundException)
           MessageBox.Show("The file was not found when saving the post.");
       else if (e == ArgumentNullException)
           MessageBox.Show("The post can't be null to be saved.");
       else
           MessageBox.Show("There was an error saving the post.");
    }
