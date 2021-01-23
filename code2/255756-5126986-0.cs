        class Member 
        { 
            [Key]
            public int MemberId { get; set; } 
            public string Name { get; set; }
            public virtual IList<FriendRelationship> Friends { get; set; } 
        }
        class FriendRelationship
        {
            [Key]
            public int RelationshipId { get; set; }
            public Member Friend { get; set; }
        }
