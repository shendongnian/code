    public class Agency : EntityBase
    	{
    		public const string AgencyRoleId = "F1776564-1CA0-11d5-A70C-00A0120802D7";
    
    		public Agency()
    		{
    			CountryId = "de";
    			LanguageId = "de";
    		}
    
    		public virtual string AgencyId { get; set; }
    		public virtual string Name { get; set; }
    		public virtual string UserDefinedName { get; set; }
    		public virtual string LanguageId { get; set; }
    		public virtual string CountryId { get; set; }
    		public virtual string RoleId
    		{
    			get
    			{
    				return AgencyRoleId;
    			}
    			set {}
    		}
    	}
    public AgencyMap()
    		{
    			Table("mgmt_location_102");
    			Id(x => x.AgencyId, "LocationId").GeneratedBy.UuidHex("D");
    			Map(x => x.CountryId, "CountryId");
    			Map(x => x.LanguageId, "LanguageId");
    			Map(x => x.Name,"CommonName");
    			
    			Join("mgmt_agency_ext", x=>
    			                        	{
    			                        		x.Optional();
    			                        		x.KeyColumn("AgencyLocationId");
    			                        		x.Map(y => y.UserDefinedName, "AgencyUserDefinedName");
    											
    			                        	});
    
    			Join("scs2.vAgencyRoles", x =>
    			{
    				x.KeyColumn("LocationId");
    				x.Map(y => y.RoleId, "RoleId").Not.Update();
    			});
    		}
