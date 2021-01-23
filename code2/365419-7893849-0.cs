    [TestMethod]
    [ExpectedException(typeof(Exception),
    "A exception has been throws.")]
    public List<Blog> SelectActiveBlogs()
    {
        List<Blog> returnCode = null;
        try
        {
            returnCode = GetQueryable<Blog>().Where(b => b.IsActive).ToList();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return returnCode;
    }
