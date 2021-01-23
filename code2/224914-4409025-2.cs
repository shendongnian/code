        public void TestSave()
        {
            Save(0, new ImageInfo[] { 
                new ImageInfo() { Title = "first title", Name = "first.jpg", Flag = true },
                new ImageInfo() { Title = "second title", Name = "second.jpg", Flag = false },
                new ImageInfo() { Title = "third title", Name = "third.jpg", Flag = false },
            });
        }
