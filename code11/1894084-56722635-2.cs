    //...
    // Arrange
    string formDataBoundary = String.Format("----------{0:N}", Guid.NewGuid());
    var formData = new MultipartFormDataContent(formDataBoundary) { //<---- NOTE HERE
        { new StringContent("Test Title"), "Title" },
        { new StringContent("Test Description"), "Description" },
        { new StringContent("String_1"), "AListOfStrings" },
        { new StringContent("String_2"), "AListOfStrings" },
        { new StringContent("3"), "NumberOfThings" }
    };
    foreach (var fileName in fileNames) {
        var document = File.ReadAllBytes($"{fileDir}/{fileName}");
        formData.Add(new ByteArrayContent(document), "Documents", fileName); //<-- NOTE HERE
    }
    // Act
    var response = await server.CreateClient().PostAsync("api/v1/item", formData);
    //...
