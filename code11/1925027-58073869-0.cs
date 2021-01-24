public struct FunctionalLocation
{
   public string Description {get; set;}
   public string FunctionalLocation {get; set;}
   public string EquipmentNo { get; set; }
   public string EquipmentCategory { get; set; }
   public string EquipmentType { get; set; }
}
public struct FunctionalLocsResponse
{
   public string StatusRet {get; set;}
   public string ErrorRet {get; set;}
}
public class FunctionalLocationCollection
{
   public string Description {get; set;}
   public string FunctionalLocation {get; set;}
   public string EquipmentNo { get; set; }
   public string EquipmentCategory { get; set; }
   public string EquipmentType { get; set; }
   public List<FunctionalLocation> ListFunctionalLocations {get; set;}
   
   public FunctionalLocsResponse AppendFunctionalLocationsSAP(List<FunctionalLocation> locationCollection)
   {
      var query = "InsertFunctionalLocationsSAP";
      var locsResponse = new clsFunctionalLocsResponse();
      locsResponse.StatusRet = "";       
      string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SAPConnection"].ConnectionString;
      using var cn = new SqlConnection(ConnectionString)
      using var cmd = new SqlCommand(query, cn)
      cmd.CommandType = CommandType.StoredProcedure;
      if (ListFunctionalLocations.Count > 0)
      {
         foreach (var item in locationCollection)
         {
            cmd.Parameters.Add("@Description", SqlDbType.VarChar, 1000).Value = item.Description;
            cmd.Parameters.Add("@FunctionalLocation", SqlDbType.VarChar, 20).Value = item.FunctionalLocation;
            cmd.Parameters.Add("@EquipmentNo", SqlDbType.VarChar, 20).Value = item.EquipmentNo;
            cmd.Parameters.Add("@EquipmentCategory", SqlDbType.VarChar, 20).Value = item.EquipmentCategory;
            cmd.Parameters.Add("@EquipmentType", SqlDbType.VarChar, 20).Value = item.EquipmentType;
            cmd.Parameters.Add("@StatusRet", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ErrorRet", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
            cn.Open();
            cmd.ExecuteNonQuery();
            locsResponse.StatusRet = Convert.ToString(cmd.Parameters["@StatusRet"].Value);
            locsResponse.ErrorRet = Convert.ToString(cmd.Parameters["@ErrorRet"].Value);
            cmd.Parameters.Clear();
            cn.Close();
         }
      }
      else 
      {
         locsResponse.StatusRet = "Failed";
         locsResponse.ErrorRet = "No data has been provided";
      }      
      return locsResponse;
   }
}
If you still need recursive nesting I advice a Child and Collection of `FunctionalLocation`, both classes.
