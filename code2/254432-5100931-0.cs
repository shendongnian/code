        public class SelectAllInLinq2SqlTests
        {
            [Fact]
            public void Unsuccessful()
            {
                var filteredLesson =
                    (from l in Lessons
                     where l.statusID == SUBMITTED ||
                           l.statusID == APPROVED &&
                           l.projectID == (l.projectID.HasValue ? projectOne : l.projectID)
                     select l).ToList();
                Assert.Equal(4, filteredLesson.Count);
                // this returned 5 items!
                // good - filtered the null project IDs and statusID == SUBMITTED
                // good - filtered the null project IDs and statusID == APPROVED
                // good - filtered the projectID == projectOne and statusID == SUBMITTED
                // good - filtered the projectID == projectOne and statusID == APPROVED
                // FAIL - filtered the projectID == projectTwo !!!
                // two failures first selecting all records containing a null projectID and any status (we wanted to filter on SUBMITTED or APPROVED)
                // the failure is due to operator precedence the 'l.statusID == SUBMITTED ||' is short-circuiting the rest of the comparison
            }
            [Fact]
            public void Unsuccessful2()
            {
                var filteredLesson =
                    (from l in Lessons
                     where !l.projectID.HasValue ||
                           (l.statusID == SUBMITTED || l.statusID == APPROVED && l.projectID == projectOne)
                     select l).ToList();
                Assert.Equal(4, filteredLesson.Count);
                // this returned 6 items!
                // good - filtered the null project IDs and statusID == SUBMITTED
                // good - filtered the null project IDs and statusID == APPROVED
                // FAIL - filtered the null project IDs and statusID == OTHER!
                // good - filtered the projectID == projectOne and statusID == SUBMITTED
                // good - filtered the projectID == projectOne and statusID == APPROVED
                // FAIL - filtered the projectID == projectTwo !!!
                // Two failures:
                //   first selecting all records containing a null projectID and any status (we wanted to filter on SUBMITTED or APPROVED)
                //   second failure is due to operator precedence the 'l.statusID == SUBMITTED ||' is short-circuiting the rest of the comparison
            }
            [Fact]
            public void Unsuccessful2NotQuiteFixed()
            {
                var filteredLesson =
                    (from l in Lessons
                     where !l.projectID.HasValue
                           || ((l.statusID == SUBMITTED || l.statusID == APPROVED)
                               && l.projectID == projectOne)
                     select l).ToList();
                Assert.Equal(4, filteredLesson.Count);
                // this returned 5 items!
                // good - filtered the null project IDs and statusID == SUBMITTED
                // good - filtered the null project IDs and statusID == APPROVED
                // FAIL - filtered the null project IDs and statusID == OTHER!
                // good - filtered the projectID == projectOne and statusID == SUBMITTED with a SUBMITTED status
                // good - filtered the projectID == projectOne and statusID == APPROVED with a APPROVED status
                // failures selecting all records containing a null projectID and any status (we wanted to filter on SUBMITTED or APPROVED)
            }
            [Fact]
            public void Sucessful()
            {
                // Questioner's provided solution...
                var filteredLesson =
                    (from l in Lessons
                     where !l.projectID.HasValue && (l.statusID == SUBMITTED || l.statusID == APPROVED)
                           || l.projectID == projectOne && (l.statusID == SUBMITTED || l.statusID == APPROVED)
                     select l).ToList();
                Assert.Equal(4, filteredLesson.Count);
            }
            [Fact]
            public void SucessfulRefined()
            {
                // cleaned up without the duplicate status comparisons. Note the parens are necessary.
                var filteredLesson =
                    (from l in Lessons
                     where (!l.projectID.HasValue || l.projectID == projectOne)
                           && (l.statusID == SUBMITTED || l.statusID == APPROVED)
                     select l).ToList();
                Assert.Equal(4, filteredLesson.Count);
            }
            public class Lesson
            {
                public int? projectID { get; set; }
                public int statusID { get; set; }
            }
            const int OTHER = 0;
            const int SUBMITTED = 1;
            const int APPROVED = 2;
            const int projectOne = 1;
            Lesson[] Lessons = new[]
                              {
                                  new Lesson { projectID = null, statusID = SUBMITTED},
                                  new Lesson { projectID = null, statusID = APPROVED},
                                  new Lesson { projectID = null, statusID = OTHER},
                                  new Lesson { projectID = 1, statusID = SUBMITTED},
                                  new Lesson { projectID = 1, statusID = APPROVED},
                                  new Lesson { projectID = 1, statusID = OTHER},
                                  new Lesson { projectID = 2, statusID = SUBMITTED},
                                  new Lesson { projectID = 2, statusID = APPROVED},
                                  new Lesson { projectID = 2, statusID = OTHER},
                              };
        }
    }
