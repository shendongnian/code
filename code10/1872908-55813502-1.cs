    [Fact]
    public void CanReadJsonValue()
    {
      ...
      using (MySqlDataReader reader = cmd.ExecuteReader())
      {
        Assert.True(reader.Read());
        Assert.Equal("[\"a\", {\"b\": [true, false]}, [10, 20]]", reader.GetString(0));
      }    
    }
