    Func<string,bool> equalsSearch = s =>
    {
        var res = s == txtSearchBox.Text;
        Debug.WriteLine("\"{0}\" == \"{1}\" ({2})", s, txtSearchBox.Text, res);
        return res;
    };
    var returnList = from TblItemEntity item in itemList
                     join TblClientEntity client in clientList
                         on item.ClientNo equals client.ClientNumber
                     join TblJobEntity job in jobList
                         on item.JobNo equals job.JobNo
                     //where item.ClientNo == txtSearchBox.Text //Is this filter wrong?
                     where equalsSearch(item.ClientNo) //use our debug filter
                     orderby client.CompanyName
                     select new { FileId = item.FileId, CompanyName = client.CompanyName, LoanStatus = item.LoanStatus, JobNo = job.JobNo, JobFinancialYE = job.JobFinancialYE, VolumeNo = item.VolumeNo };
