    var dt = dt1.AsEnumerable().Except(dt2.AsEnumerable(), new CustomDataRowEqualityComparer()).CopyToDataTable();
    
        public class CustomDataRowEqualityComparer: IEqualityComparer<DataRow>
        	{
        		
        		public bool Equals(DataRow x, DataRow y)
        		{
        			return ((int)x["crsnum"]) == ((int)y["crsnum"])
        				&& ((int)x["crsnum_e"]) == ((int)y["crsnum_e"])
        				    && ((int)x["crstteng"]) == ((int)y["crstteng"]);
        		}
        		
        		public int GetHashCode(DataRow obj)
        		{
        			return ((int)obj["crsnum"]) ^ ((int)obj["crsnum_e"]) ^ ((int)obj["crstteng"]) ;
        		}
        	}
