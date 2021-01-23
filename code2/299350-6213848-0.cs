    var subjects = (from subject in Entities.Subjects
                    from professor in subject.Lecturers
                    where professor.Professor == true
                    select new 
                        {
                            ID = subject.ID,
                            Name= subject.Name,
                            ProfessorFullName= professor.LastName+ " " + professor.Name,
                            Assistants= (from subject1 in Entities.Subjects
                                         from assistant in subject1.Lecturers
                                         where assistant.Professor == false
                                         select new SSVN.ModelView.Assistant()
                                             {
                                                 AssistantFullName = assistant.LastName+ " " + assistant.Name
                                             })
                        }).AsEnumerable().Select(x => new SSVN.ModelView.Subject
                             {
                                ID = x.ID,
                                Name = x.Name,
                                ProfessorFullName = X.ProffesorFullName,
                                Assistants = x.Assistants.ToList()
                             });
