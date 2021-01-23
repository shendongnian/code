    [Fact]
    public void Mapping_root_to_flattened_should_include_nested_properties()
    {
        // ARRANGE
        var myRoot = new Root
        {
            AParentProperty = "my AParentProperty",
            TheNestedClass = new Nested
            {
                ANestedProperty = "my ANestedProperty"
            }
        };
        
        // Manually create the mapper using the Profile
        var mapper = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile())).CreateMapper();
        
        // ACT
        var myFlattened = mapper.Map<Root, Flattened>(myRoot);
        
        // ASSERT
        Assert.Equal(myRoot.AParentProperty, myFlattened.AParentProperty);
        Assert.Equal(myRoot.TheNestedClass.ANestedProperty, myFlattened.ANestedProperty);
    }
