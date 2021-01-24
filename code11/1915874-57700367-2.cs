     try
            {
                List<Model.Participant> participants = new List<Model.Participant>();
                DataTable participantDT = new DataTable();
                //participantDT = GetYourParticipantDT;
                foreach (DataRow tmpdr in participantDT.Rows)
                {
                    Model.Participant tmpmodel = new Model.Participant(tmpdr);
                    List<Model.Discipline> disciplines = new List<Model.Discipline>();
                    DataTable disciplineDT = new DataTable();
                    // disciplineDT = GetYourDisciplineDT;
                    foreach (DataRow dr in disciplineDT.Rows)
                    {
                        disciplines.Add(new Model.Discipline(dr));
                    }
                    tmpmodel.Disciplines = disciplines;
                    participants.Add(tmpmodel);
                }
            }
            catch (Exception ex)
            {
            }
        }
