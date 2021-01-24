    private PostDto MapIntegration(IntDto integ)
    {
        var ret = new List<IntDto>();
        ret.Add(integ);
        return new PostDto
        {
            prop1 = "7",
            prop2 = "10",
            prop3 = true,
            prop4 = "EA Test",
            product_list = ret
        };
    }
