    <AllData>
        <MasterData>
            <Data>
               <SomeInnerData>
                      some inner data
              </SomeInnerData>
            </Data>
        </MasterData> 
            <MoreData>
                 <SubMoreData>moredate</SubMoreData>
         </MoreDate>
    <AllData>
    [System.SerializableAttribute()]
    public class AllData
    {
    public MasterData MasterData {get;set;}
    public MoreData MoreData {get;set;}
    }
    [System.SerializableAttribute()]
    public class Data
    {
        public string SomeInnnerData {get;set;}
    }
    [System.SerializableAttribute()]
    public class MasterData
    {
        public string SomeInnnerData {get;set;}
    }
    [System.SerializableAttribute()]
    public class MasterData
    {
        public Data Data {get;set;}
    }
     [System.SerializableAttribute()]
     public class MoreData
     {
        public string SubMoreDate {get;set;}
     }
