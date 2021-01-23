    public class MyClass 
    { 
        [Column(Name="StoredColumn", DbType="int")]     
        public int Stored;      
        [Column(Name="ForDisplay", Expression="StoredColumn * 1000")]
        public int ForDisplay 
        {        
            get { return Stored * 1000; }     
        } 
    } 
