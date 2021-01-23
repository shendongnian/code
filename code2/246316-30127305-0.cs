            [TestMethod]
            [DeploymentItem(@".\resources\velas_navidad.gif", @".\")]
            public void Post_to_photos()
            {
                var ImagePath = "velas_navidad.gif";
                Assert.IsTrue(File.Exists(ImagePath));
    
                var client = new FacebookClient(AccessToken);
                dynamic parameters = new ExpandoObject();
    
                parameters.message = "Picture_Caption";
                parameters.subject = "test 7979";
                parameters.source = new FacebookMediaObject
    {
        ContentType = "image/gif",
        FileName = Path.GetFileName(ImagePath)
    }.SetValue(File.ReadAllBytes(ImagePath));
    
                //// Post the image/picture to User wall
                dynamic result = client.Post("me/photos", parameters);
                //// Post the image/picture to the Page's Wall Photo album
                //fb.Post("/368396933231381/", parameters); //368396933231381 is Album id for that page.
    
                Thread.Sleep(15000);
                client.Delete(result.id);
            }
