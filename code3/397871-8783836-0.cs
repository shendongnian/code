    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web.DynamicData;
    
    namespace MyCompany.MyProject.DataModel
    {
        [MetadataType(typeof(InHouseClaimMetadata))]
        [ScaffoldTable(true)]
        public partial class InHouseClaim
        {
            public class InHouseClaimMetadata
            {
              
            }
        }
    }
