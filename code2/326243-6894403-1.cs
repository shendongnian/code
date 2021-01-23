    public void UpdateModalitiesId(int? CaseId, int ModalitiesId)
    
        {
            string query = "if (select count(*) from ImageModality where ImageModality.Id='"+ ModalitiesId +"') > 0 BEGIN
                                   UPDATE ImageGroup set ImageModalityId='" + ModalitiesId + "' where BaseCaseId='" + CaseId +"; END' ;
            SqlHelper.ExecuteNonQuery(strConnectionString, CommandType.Text, query);
        }
