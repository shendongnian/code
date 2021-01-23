    var memberClass1Obj = new Member {
                    Name = "Steve Smith",
                    Age = 25,
                    IsCitizen = true,
                    Birthday = DateTime.Now.AddYears(-30),
                    PetName = "Rosco",
                    PetAge = 4,
                    IsUgly = true,
                };
    
                string br = "<br /><br />";
                Response.Write(memberClass1Obj.ToJSON() + br); // just to show the JSON
    
                var memberClass2Obj = memberClass1Obj.ConvertViaJSON<MemberV2>();
                Response.Write(memberClass2Obj.ToJSON()); // valid fields are filled
