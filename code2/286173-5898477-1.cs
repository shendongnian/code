    [DataContract]
    public class DataResult
    {
        [DataMember]
        public List<data> DataList{ get; set; }
    
        DataResult(List<data> dataList)
        { 
            DataList = dataList;
        }
    
    }
    
    [OperationContract]
    public List<data> GetSum(){
        ...
        ...
    
        return DataResult(res);
    }
    
    
    
    private void Summary(object Sender, ServiceProxy.GetSumCompletedEventArgs e)
    {
        foreach (data d in e.Result.DataList)
        {
    
        }          
    }
