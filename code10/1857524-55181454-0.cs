    var content = new MultipartFormDataContent();
    for (int i = 0; i < registrationList.Count; i++)
    {
        UserForRegisterDto registration = registrationList[i];
        content.Add(new StringContent(registration.LastName), $"model[{i}].LastName");
        content.Add(new StringContent(registration.MobilePhone), $"model[{i}].MobilePhone");
        content.Add(new StringContent(registration.Name), $"model[{i}].Name");
        content.Add(new StringContent(registration.Password), $"model[{i}].Password");
        content.Add(new StringContent(registration.PhoneNumber), $"model[{i}].PhoneNumber");
        content.Add(new StringContent(registration.UserName), $"model[{i}].UserName");
        content.Add(new ByteArrayContent(registration.Photo), $"model[{i}].Photo", "photo.jpeg");
    }
    HttpResponseMessage response = await client.PostAsync($"api/users/{user.Id}/users/PostGasStationUsers/{ConfigurationManager.AppSettings["appId"].ToString()}", content);
