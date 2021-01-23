    public void DeleteUserCourse(int courseId)
            {
                var uc = (UserCoursesRepository.Query.Where(x => x.IdUser == UserId && x.IdCourse == courseId)).Single();
                UserCoursesRepository.Delete(uc);
                UserCoursesRepository.Save();
            }
