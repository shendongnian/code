    private PostDto MapIntegration(IntDto integ)
    {
        return new PostDto
        {
            prop1 = "7",
            prop2 = "10",
            prop3 = true,
            prop4 = "EA Test",
            // Create a new list with collection initializer.
            product_list = new List<IntDto>() { integ }
        };
    }
