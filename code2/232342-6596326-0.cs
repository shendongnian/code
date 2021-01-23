            Video newVideo = new Video();
            newVideo.Title = textBoxTitle.Text;// "Smideo Generated Movie";
            newVideo.Tags.Add(new MediaCategory("Travel", YouTubeNameTable.CategorySchema));
            newVideo.Keywords = textBoxKeyWords.Text;
            newVideo.Description = textBoxDescription.Text;
            newVideo.YouTubeEntry.Private = false;
            newVideo.Tags.Add(new MediaCategory("Test, Example",
              YouTubeNameTable.DeveloperTagSchema));
            try
            {
                 createdVideo = request.Upload(newVideo);
            }
            catch(InvalidCredentialsException c)
            {
                 doSomethingAboutInvalidCredentials(c);
            }
