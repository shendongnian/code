C#
public void CreateApplicant(ApplicantModel applicant, AddressModel address, GraduationModel graduation, GenderModel gender, GradeModel grade)
        {
            string query = "INSERT INTO Applicant(FirstName,LastName,PostCode,Birthday,GenderID,Email,Job,GraduationID,GradeID)" + "Values(@FirstName,@LastName,@PostCode,@Birthday,@Gender,@Email,@Job,@Graduation,@Grade)";
            try
            {
                Db.Execute(query, new
                {
                    FirstName = applicant.FirstName,
                    LastName = applicant.LastName,
                    Birthday = applicant.Birthday,
                    PostCode = applicant.PostCode,
                    Graduation = graduation.ID,
                    Gender = gender.ID,
                    Email = applicant.EMail,
                    Job = applicant.Job,
                    Grade = grade.Grade,
                });
                Logger.LogInfo("Function AddApplicant executed in ApplicantRepository!");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
And the different details are filled into textboxes which are bound to the properties of my database
