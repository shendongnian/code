    long appId = Int64.Parse(form["ApplicationId"]);
    long userId = Int64.Parse(form["UserId"]);
    Application app = appRepository.Applications.FirstOrDefault(a => a.Id == appId);
    User user = userRepository.Users.FirstOrDefault(u => u.Id == userId);
    userRepository.DetachUser(user);
    appRepository.AttachEntity(user);
    app.Administrators.Add(user);
    appRepository.SaveApplication(app);
