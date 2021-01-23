    Query.ElemMatch("Relationships", 
                     Query.And(
                             Query.EQ("RelationshipType", "Test"),
                             Query.All("Attributes.Institution", "Location1", "Location2")
                              )
                   );
