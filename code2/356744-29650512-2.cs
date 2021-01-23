            protected override void Seed(Videos.Models.VideoDb context)
            {
            context.Videos.AddOrUpdate(v => v.Title,
                new Video() { Title = "MyTitle1", Length = 150 },
                new Video() { Title = "MyTitle2", Length = 270 }
                );
            context.SaveChanges();
            }
