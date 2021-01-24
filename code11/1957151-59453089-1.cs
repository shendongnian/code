    List<MarksA> marksAs = new List<MarksA>
            {
                new MarksA{ Id = 1 , Name = "A" , Mark1 = 60 ,  Mark2 = 70,Mark3 = 80},
                new MarksA{ Id = 2 , Name = "B" , Mark1 = 40 ,  Mark2 = 50,Mark3 = 60},
                new MarksA{ Id = 3 , Name = "C" , Mark1 = 50 ,  Mark2 = 80,Mark3 = 50},
                new MarksA{ Id = 4 , Name = "D" , Mark1 = 50 ,  Mark2 = 80,Mark3 = 50}
            };
            List<MarksB> marksBs = new List<MarksB>
            {
                new MarksB{ Id = 3 , Name = "C" , Mark4 = 60 ,  Mark5 = 70,Mark6 = 60},
                new MarksB{ Id = 4 , Name = "D" , Mark4 = 78 ,  Mark5 = 55,Mark6 = 88},
                new MarksB{ Id = 5 , Name = "E" , Mark4 = 60 ,  Mark5 = 70,Mark6 = 60},
                new MarksB{ Id = 6 , Name = "F" , Mark4 = 78 ,  Mark5 = 55,Mark6 = 88}
            };
    var innerJoinMarks = marksAs.Join(marksBs,
                    post => post.Id,
                    meta => meta.Id,
                    (post, meta) => new { Post = post, Meta = meta }).Select(x => new Marks
                    {
                        Id = x.Post.Id,
                        Name = x.Post.Name,
                        Mark1 = x.Post.Mark1,
                        Mark2 = x.Post.Mark2,
                        Mark3 = x.Post.Mark3,
                        Mark4 = x.Meta.Mark4,
                        Mark5 = x.Meta.Mark5,
                        Mark6 = x.Meta.Mark6
                    }).ToList();
            var fullOuterExcludingJoin = marksAs.Where(x => innerJoinMarks.All(z => z.Id != x.Id)).Select(x => new Marks
            {
                Id = x.Id,
                Name = x.Name,
                Mark1 = x.Mark1,
                Mark2 = x.Mark2,
                Mark3 = x.Mark3
            }).Union(marksBs.Where(x => innerJoinMarks.All(z => z.Id != x.Id)).Select(x => new Marks
            {
                Id = x.Id,
                Name = x.Name,
                Mark4 = x.Mark4,
                Mark5 = x.Mark5,
                Mark6 = x.Mark6
            })).ToList();
            var fullOuterJoin = innerJoinMarks.Union(fullOuterExcludingJoin ).OrderBy(x => x.Id);
