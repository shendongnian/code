    <AllData>
    <MasterData>
    <Data>
    <SomeInnerData>
    some inner data
    </SomeInnerData>
    </Data>
    </MasterData> <MoreData>
    <SubMoreData>moredate</SubMoreData>
    </MoreDate>
    <AllData>
    [System.SerializableAttribute()]
    public class RealMasterData
    {
    public string MasterData {get;set;}
    public string MoreData {get;set;}
    }
    [System.SerializableAttribute()]
    public class MasterData
    {
        public string SomeInnnerData {get;set;}
    }
     [System.SerializableAttribute()]
     public class MoreData
     {
        public string SubMoreDate {get;set;}
     }
