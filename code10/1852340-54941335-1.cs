     var person = new Person();
                person.Educations.Add(new Education { Degree = Enums.DegreeType.High_School_Complete });
                person.Educations.Add(new Education { Degree = Enums.DegreeType.Vocational_Education_Student });
    
                var highestEd = person.Educations.Select(p => (int)p.Degree).Max();
                Enums.DegreeType enumHighest;
                Enum.TryParse(highestEd.ToString(), out enumHighest);
