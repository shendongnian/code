    if (file == null)
    {
                    
        var data = _env.WebRootFileProvider.GetFileInfo("images2/t.PNG").CreateReadStream();
        using (var ms = new MemoryStream())
        {
            data.CopyTo(ms);
            var fileBytes = ms.ToArray();
            string s = Convert.ToBase64String(fileBytes);
            person.ImagePath = s;
        }
        _context.Update(person);
        await _context.SaveChangesAsync();
    }
