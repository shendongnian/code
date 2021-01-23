    var lstReferences = from section in courseSectionToCreate.SectionsToAdd     
                        let courseNumber = section.Course.CourseNumber                           
                        let toJoin = new object[] 
                        { 
                           courseNumber.Substring(0, 5),
                           courseNumber.Substring(5),
                           section.Session,
                           section.Year,
                           section.SectionNumber
                        }
                        select string.Join(".", toJoin) + ";" 
    
    var strReferenceNumber = string.Join(", ", lstReferences); 
