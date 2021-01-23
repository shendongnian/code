     BsonClassMap.RegisterClassMap<Post>(cm =>
            {
                cm.AutoMap();
                cm.SetIdMember(cm.GetMemberMap(c => c.IdPost));
                cm.UnmapProperty(c => c.TimeStamp);
                cm.UnmapProperty(c => c.DatePostedFormat);
                cm.UnmapProperty(c => c.IdPostString);
                cm.UnmapProperty(c => c.ForumAvatar);
                cm.UnmapProperty(c => c.ForumAvatarAlt);
            });
