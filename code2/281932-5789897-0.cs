        var data = users.Where(
            user =>
                user.Username == username &&
                user.EncryptedPassword == password
            );
        if (status.HasValue)
        {
            data = data.Where(user => user.StatusID == status.Value);
        }
        return data.FirstOrDefault();
